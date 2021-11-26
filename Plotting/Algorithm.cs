﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using GraphicsHelper;
using Point = GraphicsHelper.Point;

namespace AdvancedGraphics
{
    public partial class FormPlotting
    {
        private const int scaleFactor = 100;
        private const double threshold = 5;
        private const double splitting = 100;
        private double yawAngle;
        private double pitchAngle;
        private double[] upHorizon;
        private double[] downHorizon;

        FloatingPoint getScaledPoint(Point p)
        {
            var res = AffineTransformations.rotate(p, AxisType.Y, yawAngle);
            res = AffineTransformations.rotate(res, AxisType.X, pitchAngle);
            var x = Point.worldCenter.X + scaleFactor * res.Xf;
            if (x < 0 || x >= canvas.Width)
            {
                return new FloatingPoint(x, scaleFactor * res.Yf, res.Zf * scaleFactor, Visibilty.INVISIBLE);
            }

            return new FloatingPoint(x,
                scaleFactor * res.Yf, res.Zf * scaleFactor, ref upHorizon, ref downHorizon);
        }

        public void changeViewAngles(double shiftX = 0, double shiftY = 0)
        {
            pitchAngle = Math.Clamp(pitchAngle + shiftY, -89.0, 89.0);
            yawAngle = Math.Clamp(yawAngle + shiftX, -89.0, 89.0);
        }

        Color getColorByVisibility(Visibilty v)
        {
            switch (v)
            {
                case Visibilty.VISIBLE_UP:
                    return Color.Navy;
                case Visibilty.VISIBLE_DOWN:
                    return Color.CornflowerBlue;
                default:
                    throw new ArgumentOutOfRangeException(nameof(v), v, null);
            }
        }

        void updateHorizons(FloatingPoint last, FloatingPoint curr)
        {
            if (last.X < 0 || curr.X >= canvas.Width)
            {
                return;
            }
            if (curr.X - last.X == 0)
            {
                upHorizon[curr.X] = Math.Max(upHorizon[curr.X], curr.Yf);
                downHorizon[curr.X] = Math.Min(downHorizon[curr.X], curr.Yf);
            }
            else
            {
                var tg = (curr.Yf - last.Yf) / (curr.Xf - last.Xf);
                for (int x = last.X; x <= curr.X; x++)
                {
                    var y = tg * (x - last.Xf) + last.Yf;
                    upHorizon[x] = Math.Max(upHorizon[x], y);
                    downHorizon[x] = Math.Min(downHorizon[x], y);
                }
            }
        }

        // FloatingPoint intersect(double z,double previousX, double currentX, Func<double, double, double> f, double[] hor)
        // {
        //     //  FloatingPoint mid = getScaledPoint(new Point(previousX,f(previousX,z),z));
        //     //  Visibilty startingVisibility = mid.Visibility;
        //     //  for (double x = previousX; x <= currentX; x+= 0.001)
        //     //  {
        //     //      mid = getScaledPoint(new Point(x,f(x,z),z));
        //     //      if (mid.Visibility == Visibilty.INVISIBLE)
        //     //      {
        //     //          break;
        //     //      }
        //     //  }
        //     //
        //     // return mid;
        // }
        
        ReducedFloatingPoint intersect(FloatingPoint previous, FloatingPoint curr, ref double[] horizon)
        {
            if (curr.X - previous.X == 0)
            {
                return new ReducedFloatingPoint(previous.X, (int) (horizon[previous.X]));
            }

            var tg = (curr.Yf - previous.Yf) / (curr.Xf - previous.Xf);
            var visibilityLeft = Math.Sign(previous.Yf + tg - horizon[previous.X + 1]);
            var visibilityWork = visibilityLeft;
            var y = previous.Yf + tg;
            var x = previous.X + 1;
            while (visibilityLeft == visibilityWork)
            {
                y += tg;
                x += 1;
                visibilityWork = Math.Sign(y - horizon[x]);
            }

            if (Math.Abs(y - tg - horizon[x - 1]) <= Math.Abs(y - horizon[x]))
            {
                y -= tg;
                x -= 1;
            }
            return new ReducedFloatingPoint(x, (int)(y));
        }


        // Вдохновение черпалось с сайта республики Марий Эл. Да, настолько всё плохо... http://www.mari-el.ru/mmlab/home/kg/Lection10/2.html
        void floatingHorizon(Func<double, double, double> f)
        {
            double step = threshold * 2.0 / splitting;

            upHorizon = new double[canvas.Width];
            downHorizon = new double[canvas.Width];

            for (int i = 0; i < canvas.Width; i++)
            {
                upHorizon[i] = double.MinValue;
                downHorizon[i] = double.MaxValue;
            }

            var bitmap = new Bitmap(canvas.Width, canvas.Height);
            var fbitmap = new FastBitmap.FastBitmap(bitmap);

            for (double z = threshold; z >= -threshold; z -= step)
            {
                FloatingPoint previous = getScaledPoint(new Point(-threshold, f(-threshold, z), z));
                for (double x = -threshold; x <= threshold; x += step)
                {
                    FloatingPoint current = getScaledPoint(new Point(x, f(x, z), z));

                    if (current.Visibility == Visibilty.VISIBLE_UP)
                    {
                        if (previous.Visibility != Visibilty.INVISIBLE)
                        {
                            AdditionalAlgorithms.drawVuLine(ref fbitmap, previous.toSimple2D(), current.toSimple2D(),
                                getColorByVisibility(Visibilty.VISIBLE_UP));
                            //upHorizon[current.X] = current.Yf;
                            updateHorizons(previous, current);
                        }else
                        {
                            AdditionalAlgorithms.drawVuLineWithColorStop(ref fbitmap, current.toSimple2D(), previous.toSimple2D(),
                                getColorByVisibility(current.Visibility));
                            updateHorizons(previous, current);
                        }
                        
                    }
                    else if (current.Visibility == Visibilty.VISIBLE_DOWN)
                    {
                        if (previous.Visibility != Visibilty.INVISIBLE)
                        {
                            AdditionalAlgorithms.drawVuLine(ref fbitmap, previous.toSimple2D(), current.toSimple2D(),
                                getColorByVisibility(Visibilty.VISIBLE_DOWN));
                            //downHorizon[current.X] = current.Yf;
                            updateHorizons(previous, current);
                        }
                        else
                        {
                            AdditionalAlgorithms.drawVuLineWithColorStop(ref fbitmap, current.toSimple2D(), previous.toSimple2D(),
                                getColorByVisibility(current.Visibility));
                            updateHorizons(previous, current);
                        }
                        
                    }
                    else
                    {
                        // if (previous.Visibility == Visibilty.VISIBLE_UP)
                        // {
                        //     //var mid = intersect(z,x-step,x, f,upHorizon);
                        //     var mid = intersect(previous,current,ref upHorizon);
                        //     AdditionalAlgorithms.drawVuLine(ref fbitmap, previous.toSimple2D(), mid.toSimple2D(),
                        //         getColorByVisibility(Visibilty.VISIBLE_UP));
                        //     updateHorizons(previous,mid);
                        // } else if (previous.Visibility == Visibilty.VISIBLE_DOWN)
                        // {
                        //     //var mid = intersect(z,x-step,x, f,downHorizon);
                        //     var mid = intersect(previous,current,ref downHorizon);
                        //     AdditionalAlgorithms.drawVuLine(ref fbitmap, previous.toSimple2D(), mid.toSimple2D(),
                        //         getColorByVisibility(Visibilty.VISIBLE_DOWN));
                        //     updateHorizons(previous,mid);
                        // }

                        if (previous.Visibility != Visibilty.INVISIBLE)
                        {
                            AdditionalAlgorithms.drawVuLineWithColorStop(ref fbitmap, previous.toSimple2D(), current.toSimple2D(),
                                getColorByVisibility(previous.Visibility));
                            updateHorizons(previous, current);
                        }
                    }

                    previous = current;
                }
            }

            fbitmap.Dispose();
            canvas.Image = bitmap;
        }

        void redraw()
        {
            floatingHorizon(SelectedFunction);
        }
    }
}