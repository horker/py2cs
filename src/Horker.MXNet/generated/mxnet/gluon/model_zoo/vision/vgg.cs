using System;
using System.Linq;
using System.Collections.Generic;
using static Horker.MXNet.Compat.Compat;

namespace Horker.MXNet.Gluon.ModelZoo.Vision
{
    using static Helper;
    public static partial class Helper {}
    
    // Expr
    // ImportFrom
    // Assignment of __all__
    // Import
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    
    public partial class VGG : HybridBlock
    {
        public Nn.HybridBlock Features { get; set; }
        public Nn.HybridBlock Output { get; set; }
        
        // Expr
        
        public VGG(int[] layers, int[] filters, int classes = 1000, bool batchNorm = false)
        :  base()
        {
            Assert((Len(layers) == Len(filters)), "(Len(layers) == Len(filters))");
            using (this.NameScope()){
                SetAttr("Features", this.MakeFeatures(layers, filters, batchNorm));
                this.Features.Add(new Nn.Dense(4096, activation: "relu", weightInitializer: "normal", biasInitializer: "zeros"));
                this.Features.Add(new Nn.Dropout(rate: 0.5));
                this.Features.Add(new Nn.Dense(4096, activation: "relu", weightInitializer: "normal", biasInitializer: "zeros"));
                this.Features.Add(new Nn.Dropout(rate: 0.5));
                SetAttr("Output", new Nn.Dense(classes, weightInitializer: "normal", biasInitializer: "zeros"));
            }
        }
        
        private Nn.HybridSequential MakeFeatures(int[] layers, int[] filters, bool batchNorm)
        {
            var featurizer = new Nn.Hybridsequential(prefix: "");
            foreach (var (i, num) in Enumerate(layers))
            {
                foreach (var unused in Range(num))
                {
                    featurizer.Add(new Nn.Conv2d(filters[i], kernelSize: 3, padding: 1, weightInitializer: new Xavier(rndType: "gaussian", factorType: "out", magnitude: 2), biasInitializer: "zeros"));
                    if (batchNorm){
                        featurizer.Add(new Nn.Batchnorm());
                    }
                    featurizer.Add(new Nn.Activation("relu"));
                }
                featurizer.Add(new Nn.Maxpool2d(strides: 2));
            }
            return featurizer;
        }
        
        public NDArrayOrSymbol HybridForward(object F, NDArrayOrSymbol x)
        {
            x = this.Features.Call(x);
            x = this.Output.Call(x);
            return x;
        }
    }
    
    public static partial class Helper
    {
        public static Dictionary<int, Tuple<int[], int[]>> VggSpec = new Dictionary<int, Tuple<int[], int[]>>{
            { 11, Tuple.Create(new [] { 1, 1, 2, 2, 2 }, new [] { 64, 128, 256, 512, 512 }) },
            { 13, Tuple.Create(new [] { 2, 2, 2, 2, 2 }, new [] { 64, 128, 256, 512, 512 }) },
            { 16, Tuple.Create(new [] { 2, 2, 3, 3, 3 }, new [] { 64, 128, 256, 512, 512 }) },
            { 19, Tuple.Create(new [] { 2, 2, 4, 4, 4 }, new [] { 64, 128, 256, 512, 512 }) },
        }
        ;
    }
    
    public static partial class Helper
    {
        public static Nn.HybridBlock GetVgg(int numLayers, bool pretrained = true, Context ctx = null, string root = null, bool batchNorm = false)
        {
            // Expr
            var (layers, filters) = VggSpec[numLayers];
            var net = new VGG(layers, filters, batchNorm: batchNorm);
            if (pretrained){
                // ImportFrom
                var batchNormSuffix = (batchNorm ? "_bn" : "");
                net.LoadParameters(GetModelFile(("vgg%d%s".PyFormat(Tuple.Create(numLayers, batchNormSuffix))), root: root), ctx: ctx);
            }
            return net;
        }
    }
    
    public static partial class Helper
    {
        public static Nn.HybridBlock Vgg11(bool pretrained = true, Context ctx = null, string root = null)
        {
            var batchNorm = false;
            // Expr
            return GetVgg(11, pretrained: pretrained, ctx: ctx, root: root, batchNorm: batchNorm);
        }
    }
    
    public static partial class Helper
    {
        public static Nn.HybridBlock Vgg13(bool pretrained = true, Context ctx = null, string root = null)
        {
            var batchNorm = false;
            // Expr
            return GetVgg(13, pretrained: pretrained, ctx: ctx, root: root, batchNorm: batchNorm);
        }
    }
    
    public static partial class Helper
    {
        public static Nn.HybridBlock Vgg16(bool pretrained = true, Context ctx = null, string root = null)
        {
            var batchNorm = false;
            // Expr
            return GetVgg(16, pretrained: pretrained, ctx: ctx, root: root, batchNorm: batchNorm);
        }
    }
    
    public static partial class Helper
    {
        public static Nn.HybridBlock Vgg19(bool pretrained = true, Context ctx = null, string root = null)
        {
            var batchNorm = false;
            // Expr
            return GetVgg(19, pretrained: pretrained, ctx: ctx, root: root, batchNorm: batchNorm);
        }
    }
    
    public static partial class Helper
    {
        public static Nn.HybridBlock Vgg11Bn(bool pretrained = true, Context ctx = null, string root = null)
        {
            var batchNorm = false;
            // Expr
            batchNorm = true;
            return GetVgg(11, pretrained: pretrained, ctx: ctx, root: root, batchNorm: batchNorm);
        }
    }
    
    public static partial class Helper
    {
        public static Nn.HybridBlock Vgg13Bn(bool pretrained = true, Context ctx = null, string root = null)
        {
            var batchNorm = false;
            // Expr
            batchNorm = true;
            return GetVgg(13, pretrained: pretrained, ctx: ctx, root: root, batchNorm: batchNorm);
        }
    }
    
    public static partial class Helper
    {
        public static Nn.HybridBlock Vgg16Bn(bool pretrained = true, Context ctx = null, string root = null)
        {
            var batchNorm = false;
            // Expr
            batchNorm = true;
            return GetVgg(16, pretrained: pretrained, ctx: ctx, root: root, batchNorm: batchNorm);
        }
    }
    
    public static partial class Helper
    {
        public static Nn.HybridBlock Vgg19Bn(bool pretrained = true, Context ctx = null, string root = null)
        {
            var batchNorm = false;
            // Expr
            batchNorm = true;
            return GetVgg(19, pretrained: pretrained, ctx: ctx, root: root, batchNorm: batchNorm);
        }
    }
}
