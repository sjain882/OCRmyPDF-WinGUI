﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public static class OCRParams
    {
        public static char argsSprtr = ' ';

        public static string[] ProcessingPolicy =
        {
        "",
        "--redo-ocr",
        "--force-ocr"
        };

        public static string[] PDFType =
        {
        "--output-type pdf",
        "--output-type pdfa"
        };

        public static string[] OptimisationLevel =
        {
        "",
        "--optimize 1",
        "--optimize 2",
        "--optimize 3",
        "--optimize 0"
        };

        public static string rotate = "--rotate";

        public static string deskew = "--deskew";

    }
}
