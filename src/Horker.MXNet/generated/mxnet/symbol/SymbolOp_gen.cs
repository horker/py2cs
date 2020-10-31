using System;
using Horker.MXNet;
using Horker.MXNet.Interop;

namespace Horker.MXNet
{
    public partial class Symbol : SymbolBase
    {
        public static class Op
        {
        public static SymbolList BatchNormV1(Symbol data, Symbol gamma, Symbol beta, float eps, float momentum, bool fixGamma, bool useGlobalStats, bool outputMeanVar, string symbol_name = null)
        {
            return new Operator("BatchNorm_v1")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("eps", eps)
                .SetParam("momentum", momentum)
                .SetParam("fixGamma", fixGamma)
                .SetParam("useGlobalStats", useGlobalStats)
                .SetParam("outputMeanVar", outputMeanVar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList AllFinite(NDArray data, bool initOutput, string symbol_name = null)
        {
            return new Operator("all_finite")
                .SetInput(data)
                .SetParam("initOutput", initOutput)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MultiAllFinite(SymbolList data, int numArrays, bool initOutput, string symbol_name = null)
        {
            return new Operator("multi_all_finite")
                .SetInput(data)
                .SetParam("numArrays", numArrays)
                .SetParam("initOutput", initOutput)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList KhatriRao(SymbolList args, string symbol_name = null)
        {
            return new Operator("khatri_rao")
                .SetInput(args)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Custom(SymbolList data, string opType, string symbol_name = null)
        {
            return new Operator("Custom")
                .SetInput(data)
                .SetParam("opType", opType)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList IdentityAttachKLSparseReg(Symbol data, float sparsenessTarget, float penalty, float momentum, string symbol_name = null)
        {
            return new Operator("IdentityAttachKLSparseReg")
                .SetInput(data)
                .SetParam("sparsenessTarget", sparsenessTarget)
                .SetParam("penalty", penalty)
                .SetParam("momentum", momentum)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList LeakyReLU(Symbol data, Symbol gamma, string actType, float slope, float lowerBound, float upperBound, string symbol_name = null)
        {
            return new Operator("LeakyReLU")
                .SetInput(data)
                .SetInput(gamma)
                .SetParam("actType", actType)
                .SetParam("slope", slope)
                .SetParam("lowerBound", lowerBound)
                .SetParam("upperBound", upperBound)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SoftmaxCrossEntropy(Symbol data, Symbol label, string symbol_name = null)
        {
            return new Operator("softmax_cross_entropy")
                .SetInput(data)
                .SetInput(label)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Activation(Symbol data, string actType, string symbol_name = null)
        {
            return new Operator("Activation")
                .SetInput(data)
                .SetParam("actType", actType)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BatchNorm(Symbol data, Symbol gamma, Symbol beta, Symbol movingMean, Symbol movingVar, double eps, float momentum, bool fixGamma, bool useGlobalStats, bool outputMeanVar, int axis, bool cudnnOff, string symbol_name = null)
        {
            return new Operator("BatchNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetInput(movingMean)
                .SetInput(movingVar)
                .SetParam("eps", eps)
                .SetParam("momentum", momentum)
                .SetParam("fixGamma", fixGamma)
                .SetParam("useGlobalStats", useGlobalStats)
                .SetParam("outputMeanVar", outputMeanVar)
                .SetParam("axis", axis)
                .SetParam("cudnnOff", cudnnOff)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Concat(SymbolList data, int numArgs, int dim, string symbol_name = null)
        {
            return new Operator("Concat")
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("dim", dim)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Convolution(Symbol data, Symbol weight, Symbol bias, Shape kernel, Shape stride, Shape dilate, Shape pad, int numFilter, int numGroup, long workspace, bool noBias, string cudnnTune, bool cudnnOff, string layout, string symbol_name = null)
        {
            return new Operator("Convolution")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("kernel", kernel)
                .SetParam("stride", stride)
                .SetParam("dilate", dilate)
                .SetParam("pad", pad)
                .SetParam("numFilter", numFilter)
                .SetParam("numGroup", numGroup)
                .SetParam("workspace", workspace)
                .SetParam("noBias", noBias)
                .SetParam("cudnnTune", cudnnTune)
                .SetParam("cudnnOff", cudnnOff)
                .SetParam("layout", layout)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList CTCLoss(Symbol data, Symbol label, Symbol dataLengths, Symbol labelLengths, bool useDataLengths, bool useLabelLengths, string blankLabel, string symbol_name = null)
        {
            return new Operator("CTCLoss")
                .SetInput(data)
                .SetInput(label)
                .SetInput(dataLengths)
                .SetInput(labelLengths)
                .SetParam("useDataLengths", useDataLengths)
                .SetParam("useLabelLengths", useLabelLengths)
                .SetParam("blankLabel", blankLabel)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Deconvolution(Symbol data, Symbol weight, Symbol bias, Shape kernel, Shape stride, Shape dilate, Shape pad, Shape adj, Shape targetShape, int numFilter, int numGroup, long workspace, bool noBias, string cudnnTune, bool cudnnOff, string layout, string symbol_name = null)
        {
            return new Operator("Deconvolution")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("kernel", kernel)
                .SetParam("stride", stride)
                .SetParam("dilate", dilate)
                .SetParam("pad", pad)
                .SetParam("adj", adj)
                .SetParam("targetShape", targetShape)
                .SetParam("numFilter", numFilter)
                .SetParam("numGroup", numGroup)
                .SetParam("workspace", workspace)
                .SetParam("noBias", noBias)
                .SetParam("cudnnTune", cudnnTune)
                .SetParam("cudnnOff", cudnnOff)
                .SetParam("layout", layout)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Dropout(Symbol data, float p, string mode, Shape axes, bool cudnnOff, string symbol_name = null)
        {
            return new Operator("Dropout")
                .SetInput(data)
                .SetParam("p", p)
                .SetParam("mode", mode)
                .SetParam("axes", axes)
                .SetParam("cudnnOff", cudnnOff)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList FullyConnected(Symbol data, Symbol weight, Symbol bias, int numHidden, bool noBias, bool flatten, string symbol_name = null)
        {
            return new Operator("FullyConnected")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("numHidden", numHidden)
                .SetParam("noBias", noBias)
                .SetParam("flatten", flatten)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList LayerNorm(Symbol data, Symbol gamma, Symbol beta, int axis, float eps, bool outputMeanVar, string symbol_name = null)
        {
            return new Operator("LayerNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("axis", axis)
                .SetParam("eps", eps)
                .SetParam("outputMeanVar", outputMeanVar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList LRN(Symbol data, float alpha, float beta, float knorm, int nsize, string symbol_name = null)
        {
            return new Operator("LRN")
                .SetInput(data)
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetParam("knorm", knorm)
                .SetParam("nsize", nsize)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Moments(Symbol data, Shape axes, bool keepdims, string symbol_name = null)
        {
            return new Operator("moments")
                .SetInput(data)
                .SetParam("axes", axes)
                .SetParam("keepdims", keepdims)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Pooling(Symbol data, Shape kernel, string poolType, bool globalPool, bool cudnnOff, string poolingConvention, Shape stride, Shape pad, int pValue, bool countIncludePad, string layout, string symbol_name = null)
        {
            return new Operator("Pooling")
                .SetInput(data)
                .SetParam("kernel", kernel)
                .SetParam("poolType", poolType)
                .SetParam("globalPool", globalPool)
                .SetParam("cudnnOff", cudnnOff)
                .SetParam("poolingConvention", poolingConvention)
                .SetParam("stride", stride)
                .SetParam("pad", pad)
                .SetParam("pValue", pValue)
                .SetParam("countIncludePad", countIncludePad)
                .SetParam("layout", layout)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Softmax(Symbol data, int axis, double temperature, string dtype, string symbol_name = null)
        {
            return new Operator("softmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Softmin(Symbol data, int axis, double temperature, string dtype, string symbol_name = null)
        {
            return new Operator("softmin")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList LogSoftmax(Symbol data, int axis, double temperature, string dtype, string symbol_name = null)
        {
            return new Operator("log_softmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SoftmaxActivation(Symbol data, string mode, string symbol_name = null)
        {
            return new Operator("SoftmaxActivation")
                .SetInput(data)
                .SetParam("mode", mode)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList UpSampling(SymbolList data, int scale, int numFilter, string sampleType, string multiInputMode, int numArgs, long workspace, string symbol_name = null)
        {
            return new Operator("UpSampling")
                .SetInput(data)
                .SetParam("scale", scale)
                .SetParam("numFilter", numFilter)
                .SetParam("sampleType", sampleType)
                .SetParam("multiInputMode", multiInputMode)
                .SetParam("numArgs", numArgs)
                .SetParam("workspace", workspace)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SignsgdUpdate(Symbol weight, Symbol grad, float lr, float wd, float rescaleGrad, float clipGradient, string symbol_name = null)
        {
            return new Operator("signsgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SignumUpdate(Symbol weight, Symbol grad, Symbol mom, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, float wdLh, string symbol_name = null)
        {
            return new Operator("signum_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("wdLh", wdLh)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MultiSgdUpdate(SymbolList data, object lrs, object wds, float rescaleGrad, float clipGradient, int numWeights, string symbol_name = null)
        {
            return new Operator("multi_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("numWeights", numWeights)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MultiSgdMomUpdate(SymbolList data, object lrs, object wds, float momentum, float rescaleGrad, float clipGradient, int numWeights, string symbol_name = null)
        {
            return new Operator("multi_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("numWeights", numWeights)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MultiMpSgdUpdate(SymbolList data, object lrs, object wds, float rescaleGrad, float clipGradient, int numWeights, string symbol_name = null)
        {
            return new Operator("multi_mp_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("numWeights", numWeights)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MultiMpSgdMomUpdate(SymbolList data, object lrs, object wds, float momentum, float rescaleGrad, float clipGradient, int numWeights, string symbol_name = null)
        {
            return new Operator("multi_mp_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("numWeights", numWeights)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SgdUpdate(Symbol weight, Symbol grad, float lr, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, string symbol_name = null)
        {
            return new Operator("sgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("lazyUpdate", lazyUpdate)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SgdMomUpdate(Symbol weight, Symbol grad, Symbol mom, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, string symbol_name = null)
        {
            return new Operator("sgd_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("lazyUpdate", lazyUpdate)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MpSgdUpdate(Symbol weight, Symbol grad, Symbol weight32, float lr, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, string symbol_name = null)
        {
            return new Operator("mp_sgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(weight32)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("lazyUpdate", lazyUpdate)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MpSgdMomUpdate(Symbol weight, Symbol grad, Symbol mom, Symbol weight32, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, string symbol_name = null)
        {
            return new Operator("mp_sgd_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetInput(weight32)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("lazyUpdate", lazyUpdate)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList FtmlUpdate(Symbol weight, Symbol grad, Symbol d, Symbol v, Symbol z, float lr, float beta1, float beta2, double epsilon, int t, float wd, float rescaleGrad, float clipGrad, string symbol_name = null)
        {
            return new Operator("ftml_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(d)
                .SetInput(v)
                .SetInput(z)
                .SetParam("lr", lr)
                .SetParam("beta1", beta1)
                .SetParam("beta2", beta2)
                .SetParam("epsilon", epsilon)
                .SetParam("t", t)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGrad", clipGrad)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList AdamUpdate(Symbol weight, Symbol grad, Symbol mean, Symbol var, float lr, float beta1, float beta2, float epsilon, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, string symbol_name = null)
        {
            return new Operator("adam_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mean)
                .SetInput(var)
                .SetParam("lr", lr)
                .SetParam("beta1", beta1)
                .SetParam("beta2", beta2)
                .SetParam("epsilon", epsilon)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("lazyUpdate", lazyUpdate)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList NagMomUpdate(Symbol weight, Symbol grad, Symbol mom, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, string symbol_name = null)
        {
            return new Operator("nag_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MpNagMomUpdate(Symbol weight, Symbol grad, Symbol mom, Symbol weight32, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, string symbol_name = null)
        {
            return new Operator("mp_nag_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetInput(weight32)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList RmspropUpdate(Symbol weight, Symbol grad, Symbol n, float lr, float gamma1, float epsilon, float wd, float rescaleGrad, float clipGradient, float clipWeights, string symbol_name = null)
        {
            return new Operator("rmsprop_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(n)
                .SetParam("lr", lr)
                .SetParam("gamma1", gamma1)
                .SetParam("epsilon", epsilon)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("clipWeights", clipWeights)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList RmspropalexUpdate(Symbol weight, Symbol grad, Symbol n, Symbol g, Symbol delta, float lr, float gamma1, float gamma2, float epsilon, float wd, float rescaleGrad, float clipGradient, float clipWeights, string symbol_name = null)
        {
            return new Operator("rmspropalex_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(n)
                .SetInput(g)
                .SetInput(delta)
                .SetParam("lr", lr)
                .SetParam("gamma1", gamma1)
                .SetParam("gamma2", gamma2)
                .SetParam("epsilon", epsilon)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("clipWeights", clipWeights)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList FtrlUpdate(Symbol weight, Symbol grad, Symbol z, Symbol n, float lr, float lamda1, float beta, float wd, float rescaleGrad, float clipGradient, string symbol_name = null)
        {
            return new Operator("ftrl_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(z)
                .SetInput(n)
                .SetParam("lr", lr)
                .SetParam("lamda1", lamda1)
                .SetParam("beta", beta)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Pad(Symbol data, string mode, Shape padWidth, double constantValue, string symbol_name = null)
        {
            return new Operator("Pad")
                .SetInput(data)
                .SetParam("mode", mode)
                .SetParam("padWidth", padWidth)
                .SetParam("constantValue", constantValue)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Flatten(Symbol data, string symbol_name = null)
        {
            return new Operator("Flatten")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList LinearRegressionOutput(Symbol data, Symbol label, float gradScale, string symbol_name = null)
        {
            return new Operator("LinearRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("gradScale", gradScale)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MAERegressionOutput(Symbol data, Symbol label, float gradScale, string symbol_name = null)
        {
            return new Operator("MAERegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("gradScale", gradScale)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList LogisticRegressionOutput(Symbol data, Symbol label, float gradScale, string symbol_name = null)
        {
            return new Operator("LogisticRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("gradScale", gradScale)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList RNN(Symbol data, Symbol parameters, Symbol state, Symbol stateCell, Symbol sequenceLength, int stateSize, int numLayers, bool bidirectional, string mode, float p, bool stateOutputs, int projectionSize, double lstmStateClipMin, double lstmStateClipMax, bool lstmStateClipNan, bool useSequenceLength, string symbol_name = null)
        {
            return new Operator("RNN")
                .SetInput(data)
                .SetInput(parameters)
                .SetInput(state)
                .SetInput(stateCell)
                .SetInput(sequenceLength)
                .SetParam("stateSize", stateSize)
                .SetParam("numLayers", numLayers)
                .SetParam("bidirectional", bidirectional)
                .SetParam("mode", mode)
                .SetParam("p", p)
                .SetParam("stateOutputs", stateOutputs)
                .SetParam("projectionSize", projectionSize)
                .SetParam("lstmStateClipMin", lstmStateClipMin)
                .SetParam("lstmStateClipMax", lstmStateClipMax)
                .SetParam("lstmStateClipNan", lstmStateClipNan)
                .SetParam("useSequenceLength", useSequenceLength)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SliceChannel(Symbol data, int numOutputs, int axis, bool squeezeAxis, string symbol_name = null)
        {
            return new Operator("SliceChannel")
                .SetInput(data)
                .SetParam("numOutputs", numOutputs)
                .SetParam("axis", axis)
                .SetParam("squeezeAxis", squeezeAxis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SoftmaxOutput(Symbol data, Symbol label, float gradScale, float ignoreLabel, bool multiOutput, bool useIgnore, bool preserveShape, string normalization, bool outGrad, float smoothAlpha, string symbol_name = null)
        {
            return new Operator("SoftmaxOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("gradScale", gradScale)
                .SetParam("ignoreLabel", ignoreLabel)
                .SetParam("multiOutput", multiOutput)
                .SetParam("useIgnore", useIgnore)
                .SetParam("preserveShape", preserveShape)
                .SetParam("normalization", normalization)
                .SetParam("outGrad", outGrad)
                .SetParam("smoothAlpha", smoothAlpha)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SwapAxis(Symbol data, int dim1, int dim2, string symbol_name = null)
        {
            return new Operator("SwapAxis")
                .SetInput(data)
                .SetParam("dim1", dim1)
                .SetParam("dim2", dim2)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList AmpCast(Symbol data, string dtype, string symbol_name = null)
        {
            return new Operator("amp_cast")
                .SetInput(data)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList AmpMulticast(SymbolList data, int numOutputs, string symbol_name = null)
        {
            return new Operator("amp_multicast")
                .SetInput(data)
                .SetParam("numOutputs", numOutputs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Argmax(Symbol data, int axis, bool keepdims, string symbol_name = null)
        {
            return new Operator("argmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Argmin(Symbol data, int axis, bool keepdims, string symbol_name = null)
        {
            return new Operator("argmin")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ArgmaxChannel(Symbol data, string symbol_name = null)
        {
            return new Operator("argmax_channel")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Pick(Symbol data, Symbol index, int axis, bool keepdims, string mode, string symbol_name = null)
        {
            return new Operator("pick")
                .SetInput(data)
                .SetInput(index)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("mode", mode)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Sum(Symbol data, Shape axis, bool keepdims, bool exclude, string symbol_name = null)
        {
            return new Operator("sum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Mean(Symbol data, Shape axis, bool keepdims, bool exclude, string symbol_name = null)
        {
            return new Operator("mean")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Prod(Symbol data, Shape axis, bool keepdims, bool exclude, string symbol_name = null)
        {
            return new Operator("prod")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Nansum(Symbol data, Shape axis, bool keepdims, bool exclude, string symbol_name = null)
        {
            return new Operator("nansum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Nanprod(Symbol data, Shape axis, bool keepdims, bool exclude, string symbol_name = null)
        {
            return new Operator("nanprod")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Max(Symbol data, Shape axis, bool keepdims, bool exclude, string symbol_name = null)
        {
            return new Operator("max")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Min(Symbol data, Shape axis, bool keepdims, bool exclude, string symbol_name = null)
        {
            return new Operator("min")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastAxis(Symbol data, Shape axis, Shape size, string symbol_name = null)
        {
            return new Operator("broadcast_axis")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("size", size)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastTo(Symbol data, Shape shape, string symbol_name = null)
        {
            return new Operator("broadcast_to")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastLike(Symbol lhs, Symbol rhs, Shape lhsAxes, Shape rhsAxes, string symbol_name = null)
        {
            return new Operator("broadcast_like")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("lhsAxes", lhsAxes)
                .SetParam("rhsAxes", rhsAxes)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Norm(Symbol data, int ord, Shape axis, string outDtype, bool keepdims, string symbol_name = null)
        {
            return new Operator("norm")
                .SetInput(data)
                .SetParam("ord", ord)
                .SetParam("axis", axis)
                .SetParam("outDtype", outDtype)
                .SetParam("keepdims", keepdims)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList CastStorage(Symbol data, string stype, string symbol_name = null)
        {
            return new Operator("cast_storage")
                .SetInput(data)
                .SetParam("stype", stype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Where(Symbol condition, Symbol x, Symbol y, string symbol_name = null)
        {
            return new Operator("where")
                .SetInput(condition)
                .SetInput(x)
                .SetInput(y)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Diag(Symbol data, int k, int axis1, int axis2, string symbol_name = null)
        {
            return new Operator("diag")
                .SetInput(data)
                .SetParam("k", k)
                .SetParam("axis1", axis1)
                .SetParam("axis2", axis2)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Dot(Symbol lhs, Symbol rhs, bool transposea, bool transposeb, string forwardStype, string symbol_name = null)
        {
            return new Operator("dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transposea", transposea)
                .SetParam("transposeb", transposeb)
                .SetParam("forwardStype", forwardStype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BatchDot(Symbol lhs, Symbol rhs, bool transposea, bool transposeb, string forwardStype, string symbol_name = null)
        {
            return new Operator("batch_dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transposea", transposea)
                .SetParam("transposeb", transposeb)
                .SetParam("forwardStype", forwardStype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastAdd(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastSub(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_sub")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastMul(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_mul")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastDiv(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_div")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastMod(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_mod")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastPower(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_power")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastMaximum(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_maximum")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastMinimum(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_minimum")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastHypot(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_hypot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastEqual(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastNotEqual(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_not_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastGreater(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_greater")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastGreaterEqual(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_greater_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastLesser(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_lesser")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastLesserEqual(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_lesser_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastLogicalAnd(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_logical_and")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastLogicalOr(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_logical_or")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BroadcastLogicalXor(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("broadcast_logical_xor")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ElemwiseAdd(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("elemwise_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ElemwiseSub(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("elemwise_sub")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ElemwiseMul(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("elemwise_mul")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ElemwiseDiv(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("elemwise_div")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SmoothL1(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("smooth_l1")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Addn(SymbolList args, string symbol_name = null)
        {
            return new Operator("add_n")
                .SetInput(args)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Relu(Symbol data, string symbol_name = null)
        {
            return new Operator("relu")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Sigmoid(Symbol data, string symbol_name = null)
        {
            return new Operator("sigmoid")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList HardSigmoid(Symbol data, float alpha, float beta, string symbol_name = null)
        {
            return new Operator("hard_sigmoid")
                .SetInput(data)
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Softsign(Symbol data, string symbol_name = null)
        {
            return new Operator("softsign")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BlockGrad(Symbol data, string symbol_name = null)
        {
            return new Operator("BlockGrad")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MakeLoss(Symbol data, string symbol_name = null)
        {
            return new Operator("make_loss")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ReshapeLike(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("reshape_like")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ShapeArray(Symbol data, int lhsBegin, int lhsEnd, int rhsBegin, int rhsEnd, string symbol_name = null)
        {
            return new Operator("shape_array")
                .SetInput(data)
                .SetParam("lhsBegin", lhsBegin)
                .SetParam("lhsEnd", lhsEnd)
                .SetParam("rhsBegin", rhsBegin)
                .SetParam("rhsEnd", rhsEnd)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SizeArray(Symbol data, string symbol_name = null)
        {
            return new Operator("size_array")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Cast(Symbol data, string dtype, string symbol_name = null)
        {
            return new Operator("Cast")
                .SetInput(data)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Negative(Symbol data, string symbol_name = null)
        {
            return new Operator("negative")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Reciprocal(Symbol data, string symbol_name = null)
        {
            return new Operator("reciprocal")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Abs(Symbol data, string symbol_name = null)
        {
            return new Operator("abs")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Sign(Symbol data, string symbol_name = null)
        {
            return new Operator("sign")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Round(Symbol data, string symbol_name = null)
        {
            return new Operator("round")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Rint(Symbol data, string symbol_name = null)
        {
            return new Operator("rint")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Ceil(Symbol data, string symbol_name = null)
        {
            return new Operator("ceil")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Floor(Symbol data, string symbol_name = null)
        {
            return new Operator("floor")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Trunc(Symbol data, string symbol_name = null)
        {
            return new Operator("trunc")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Fix(Symbol data, string symbol_name = null)
        {
            return new Operator("fix")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Square(Symbol data, string symbol_name = null)
        {
            return new Operator("square")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Sqrt(Symbol data, string symbol_name = null)
        {
            return new Operator("sqrt")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Rsqrt(Symbol data, string symbol_name = null)
        {
            return new Operator("rsqrt")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Cbrt(Symbol data, string symbol_name = null)
        {
            return new Operator("cbrt")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Erf(Symbol data, string symbol_name = null)
        {
            return new Operator("erf")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Erfinv(Symbol data, string symbol_name = null)
        {
            return new Operator("erfinv")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Rcbrt(Symbol data, string symbol_name = null)
        {
            return new Operator("rcbrt")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Exp(Symbol data, string symbol_name = null)
        {
            return new Operator("exp")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Log(Symbol data, string symbol_name = null)
        {
            return new Operator("log")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Log10(Symbol data, string symbol_name = null)
        {
            return new Operator("log10")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Log2(Symbol data, string symbol_name = null)
        {
            return new Operator("log2")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Log1p(Symbol data, string symbol_name = null)
        {
            return new Operator("log1p")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Expm1(Symbol data, string symbol_name = null)
        {
            return new Operator("expm1")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Gamma(Symbol data, string symbol_name = null)
        {
            return new Operator("gamma")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Gammaln(Symbol data, string symbol_name = null)
        {
            return new Operator("gammaln")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList LogicalNot(Symbol data, string symbol_name = null)
        {
            return new Operator("logical_not")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Sin(Symbol data, string symbol_name = null)
        {
            return new Operator("sin")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Cos(Symbol data, string symbol_name = null)
        {
            return new Operator("cos")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Tan(Symbol data, string symbol_name = null)
        {
            return new Operator("tan")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Arcsin(Symbol data, string symbol_name = null)
        {
            return new Operator("arcsin")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Arccos(Symbol data, string symbol_name = null)
        {
            return new Operator("arccos")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Arctan(Symbol data, string symbol_name = null)
        {
            return new Operator("arctan")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Degrees(Symbol data, string symbol_name = null)
        {
            return new Operator("degrees")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Radians(Symbol data, string symbol_name = null)
        {
            return new Operator("radians")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Sinh(Symbol data, string symbol_name = null)
        {
            return new Operator("sinh")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Cosh(Symbol data, string symbol_name = null)
        {
            return new Operator("cosh")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Tanh(Symbol data, string symbol_name = null)
        {
            return new Operator("tanh")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Arcsinh(Symbol data, string symbol_name = null)
        {
            return new Operator("arcsinh")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Arccosh(Symbol data, string symbol_name = null)
        {
            return new Operator("arccosh")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Arctanh(Symbol data, string symbol_name = null)
        {
            return new Operator("arctanh")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Embedding(Symbol data, Symbol weight, int inputDim, int outputDim, string dtype, bool sparseGrad, string symbol_name = null)
        {
            return new Operator("Embedding")
                .SetInput(data)
                .SetInput(weight)
                .SetParam("inputDim", inputDim)
                .SetParam("outputDim", outputDim)
                .SetParam("dtype", dtype)
                .SetParam("sparseGrad", sparseGrad)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Take(Symbol a, Symbol indices, int axis, string mode, string symbol_name = null)
        {
            return new Operator("take")
                .SetInput(a)
                .SetInput(indices)
                .SetParam("axis", axis)
                .SetParam("mode", mode)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BatchTake(Symbol a, Symbol indices, string symbol_name = null)
        {
            return new Operator("batch_take")
                .SetInput(a)
                .SetInput(indices)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList OneHot(Symbol indices, int depth, double onValue, double offValue, string dtype, string symbol_name = null)
        {
            return new Operator("one_hot")
                .SetInput(indices)
                .SetParam("depth", depth)
                .SetParam("onValue", onValue)
                .SetParam("offValue", offValue)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList GatherNd(Symbol data, Symbol indices, string symbol_name = null)
        {
            return new Operator("gather_nd")
                .SetInput(data)
                .SetInput(indices)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ScatterNd(Symbol data, Symbol indices, Shape shape, string symbol_name = null)
        {
            return new Operator("scatter_nd")
                .SetInput(data)
                .SetInput(indices)
                .SetParam("shape", shape)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ZerosLike(Symbol data, string symbol_name = null)
        {
            return new Operator("zeros_like")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList OnesLike(Symbol data, string symbol_name = null)
        {
            return new Operator("ones_like")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Reshape(Symbol data, Shape shape, bool reverse, Shape targetShape, bool keepHighest, string symbol_name = null)
        {
            return new Operator("Reshape")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("reverse", reverse)
                .SetParam("targetShape", targetShape)
                .SetParam("keepHighest", keepHighest)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Transpose(Symbol data, Shape axes, string symbol_name = null)
        {
            return new Operator("transpose")
                .SetInput(data)
                .SetParam("axes", axes)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ExpandDims(Symbol data, int axis, string symbol_name = null)
        {
            return new Operator("expand_dims")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Slice(Symbol data, Shape begin, Shape end, Shape step, string symbol_name = null)
        {
            return new Operator("slice")
                .SetInput(data)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetParam("step", step)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SliceAxis(Symbol data, int axis, int begin, int end, string symbol_name = null)
        {
            return new Operator("slice_axis")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SliceLike(Symbol data, Symbol shapeLike, Shape axes, string symbol_name = null)
        {
            return new Operator("slice_like")
                .SetInput(data)
                .SetInput(shapeLike)
                .SetParam("axes", axes)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Clip(Symbol data, float aMin, float aMax, string symbol_name = null)
        {
            return new Operator("clip")
                .SetInput(data)
                .SetParam("aMin", aMin)
                .SetParam("aMax", aMax)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Repeat(Symbol data, int repeats, int axis, string symbol_name = null)
        {
            return new Operator("repeat")
                .SetInput(data)
                .SetParam("repeats", repeats)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Tile(Symbol data, Shape reps, string symbol_name = null)
        {
            return new Operator("tile")
                .SetInput(data)
                .SetParam("reps", reps)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Reverse(Symbol data, Shape axis, string symbol_name = null)
        {
            return new Operator("reverse")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Stack(SymbolList data, int axis, int numArgs, string symbol_name = null)
        {
            return new Operator("stack")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("numArgs", numArgs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Squeeze(SymbolList data, Shape axis, string symbol_name = null)
        {
            return new Operator("squeeze")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList DepthToSpace(Symbol data, int blockSize, string symbol_name = null)
        {
            return new Operator("depth_to_space")
                .SetInput(data)
                .SetParam("blockSize", blockSize)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SpaceToDepth(Symbol data, int blockSize, string symbol_name = null)
        {
            return new Operator("space_to_depth")
                .SetInput(data)
                .SetParam("blockSize", blockSize)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Topk(Symbol data, int axis, int k, string retTyp, bool isAscend, string dtype, string symbol_name = null)
        {
            return new Operator("topk")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("k", k)
                .SetParam("retTyp", retTyp)
                .SetParam("isAscend", isAscend)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Sort(Symbol data, int axis, bool isAscend, string symbol_name = null)
        {
            return new Operator("sort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("isAscend", isAscend)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Argsort(Symbol data, int axis, bool isAscend, string dtype, string symbol_name = null)
        {
            return new Operator("argsort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("isAscend", isAscend)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList BilinearSampler(Symbol data, Symbol grid, bool cudnnOff, string symbol_name = null)
        {
            return new Operator("BilinearSampler")
                .SetInput(data)
                .SetInput(grid)
                .SetParam("cudnnOff", cudnnOff)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ConvolutionV1(Symbol data, Symbol weight, Symbol bias, Shape kernel, Shape stride, Shape dilate, Shape pad, int numFilter, int numGroup, long workspace, bool noBias, string cudnnTune, bool cudnnOff, string layout, string symbol_name = null)
        {
            return new Operator("Convolution_v1")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("kernel", kernel)
                .SetParam("stride", stride)
                .SetParam("dilate", dilate)
                .SetParam("pad", pad)
                .SetParam("numFilter", numFilter)
                .SetParam("numGroup", numGroup)
                .SetParam("workspace", workspace)
                .SetParam("noBias", noBias)
                .SetParam("cudnnTune", cudnnTune)
                .SetParam("cudnnOff", cudnnOff)
                .SetParam("layout", layout)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Correlation(Symbol data1, Symbol data2, int kernelSize, int maxDisplacement, int stride1, int stride2, int padSize, bool isMultiply, string symbol_name = null)
        {
            return new Operator("Correlation")
                .SetInput(data1)
                .SetInput(data2)
                .SetParam("kernelSize", kernelSize)
                .SetParam("maxDisplacement", maxDisplacement)
                .SetParam("stride1", stride1)
                .SetParam("stride2", stride2)
                .SetParam("padSize", padSize)
                .SetParam("isMultiply", isMultiply)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList Crop(SymbolList data, int numArgs, Shape offset, Shape hw, bool centerCrop, string symbol_name = null)
        {
            return new Operator("Crop")
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("offset", offset)
                .SetParam("hw", hw)
                .SetParam("centerCrop", centerCrop)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList GridGenerator(Symbol data, string transformType, Shape targetShape, string symbol_name = null)
        {
            return new Operator("GridGenerator")
                .SetInput(data)
                .SetParam("transformType", transformType)
                .SetParam("targetShape", targetShape)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList InstanceNorm(Symbol data, Symbol gamma, Symbol beta, float eps, string symbol_name = null)
        {
            return new Operator("InstanceNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("eps", eps)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList L2Normalization(Symbol data, float eps, string mode, string symbol_name = null)
        {
            return new Operator("L2Normalization")
                .SetInput(data)
                .SetParam("eps", eps)
                .SetParam("mode", mode)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList MakeLoss(Symbol data, float gradScale, float validThresh, string normalization, string symbol_name = null)
        {
            return new Operator("MakeLoss")
                .SetInput(data)
                .SetParam("gradScale", gradScale)
                .SetParam("validThresh", validThresh)
                .SetParam("normalization", normalization)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList PoolingV1(Symbol data, Shape kernel, string poolType, bool globalPool, string poolingConvention, Shape stride, Shape pad, string symbol_name = null)
        {
            return new Operator("Pooling_v1")
                .SetInput(data)
                .SetParam("kernel", kernel)
                .SetParam("poolType", poolType)
                .SetParam("globalPool", globalPool)
                .SetParam("poolingConvention", poolingConvention)
                .SetParam("stride", stride)
                .SetParam("pad", pad)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList ROIPooling(Symbol data, Symbol rois, Shape pooledSize, float spatialScale, string symbol_name = null)
        {
            return new Operator("ROIPooling")
                .SetInput(data)
                .SetInput(rois)
                .SetParam("pooledSize", pooledSize)
                .SetParam("spatialScale", spatialScale)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SequenceLast(Symbol data, Symbol sequenceLength, bool useSequenceLength, int axis, string symbol_name = null)
        {
            return new Operator("SequenceLast")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("useSequenceLength", useSequenceLength)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SequenceMask(Symbol data, Symbol sequenceLength, bool useSequenceLength, float value, int axis, string symbol_name = null)
        {
            return new Operator("SequenceMask")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("useSequenceLength", useSequenceLength)
                .SetParam("value", value)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SequenceReverse(Symbol data, Symbol sequenceLength, bool useSequenceLength, int axis, string symbol_name = null)
        {
            return new Operator("SequenceReverse")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("useSequenceLength", useSequenceLength)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SpatialTransformer(Symbol data, Symbol loc, Shape targetShape, string transformType, string samplerType, bool cudnnOff, string symbol_name = null)
        {
            return new Operator("SpatialTransformer")
                .SetInput(data)
                .SetInput(loc)
                .SetParam("targetShape", targetShape)
                .SetParam("transformType", transformType)
                .SetParam("samplerType", samplerType)
                .SetParam("cudnnOff", cudnnOff)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList SVMOutput(Symbol data, Symbol label, float margin, float regularizationCoefficient, bool useLinear, string symbol_name = null)
        {
            return new Operator("SVMOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("margin", margin)
                .SetParam("regularizationCoefficient", regularizationCoefficient)
                .SetParam("useLinear", useLinear)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList FillElement0index(NDArray lhs, NDArray mhs, NDArray rhs, string symbol_name = null)
        {
            return new Operator("fill_element_0index")
                .SetInput(lhs)
                .SetInput(mhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        }
    }
}
