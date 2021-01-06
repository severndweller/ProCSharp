﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHeirarchy
{
    interface IDrawable
    {
        void Draw();
    }

    interface IAdvancedDraw : IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);

        void DrawUpsideDown();
    }
}
