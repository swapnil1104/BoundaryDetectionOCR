/*using SVM;
using System.IO;

    public class SVMClassifier
    {
        Model model;
        

        public void trainClassifier(string trainFileName)
        {
            Problem train = Problem.Read(trainFileName);
            Parameter param = new Parameter();
            param.C = 32;
            param.Gamma = 8;
            model = Training.Train(train, param);
        }
        public void testClassifier(string testfileName)
       { 
            Problem test = Problem.Read(testfileName);
            Prediction.Predict(test, @"E:\ocr\input\result", model, false);
        }
    }*/
using SVM;

public class SVMClassifier
{
    public void Classify()
    {
        Problem train = Problem.Read(@"e:\ocr\ProcessedImages\train.txt");
        Problem test = Problem.Read(@"e:\ocr\input\feature");

        Parameter param = new Parameter();
        double C;
        double Gamma;
        param.C = 64;
        param.Gamma = 16;
        Model model = Training.Train(train, param);
        Prediction.Predict(test, @"E:\ocr\results.txt", model, false);
    }
}