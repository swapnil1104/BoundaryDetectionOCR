using System;

namespace Classifier
{
    class StringValues
    {
        public string datasetPath = @"E:\ocr\Dataset\Sample0";
        public string dataStorePath = @"E:\ocr\ProcessedImages\";
        public string trainFilePath = @"E:\ocr\ProcessedImages\train.txt";
        public string browseFilePath= "";
        public string browseFileBoundaryDetectionPath = @"E:\ocr\input\";
        public string browseFileFeatureExtractionFile = @"E:\ocr\input\feature.txt";
        public string finalOutputFile = @"E:\ocr\results.txt";
   
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
