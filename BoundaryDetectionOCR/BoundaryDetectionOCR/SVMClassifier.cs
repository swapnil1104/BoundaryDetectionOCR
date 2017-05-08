using SVM;
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
    }
