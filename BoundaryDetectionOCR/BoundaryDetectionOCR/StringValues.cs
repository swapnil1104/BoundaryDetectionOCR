using System;

namespace Classifier
{
    class StringValues
    {
        public string datasetPath = @"E:\ocr\Dataset\Sample0";
        public string dataStorePath = @"E:\ocr\ProcessedImages\";
        public string trainFilePath = @"E:\ocr\ProcessedImages\train.txt";
        public string browseFilePath= "";
        public string browseBoundaryDetectionPath = @"E:\ocr\input\";
        public string browseFeatureExtractionFile = @"E:\ocr\input\feature";
   
        public string GetbrowseFilePath()
        {
            return browseFilePath;
        }

        public void SetbrowseFilePath(string value)
        {
            browseFilePath = value;
        }
        
    }
}
