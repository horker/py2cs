using System;
using Horker.MXNet;
using Horker.MXNet.Interop;

namespace Horker.MXNet
{
    public partial class NDArray : NDArrayBase
    {
        public static class Op
        {
        public static NDArrayList BatchNormV1(NDArray data, NDArray gamma, NDArray beta, float eps, float momentum, bool fixGamma, bool useGlobalStats, bool outputMeanVar, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList AllFinite(NDArray data, bool initOutput, NDArrayList @out = null)
        {
            return new Operator("all_finite")
                .SetInput(data)
                .SetParam("initOutput", initOutput)
                .Invoke(@out);
        }

        public static NDArrayList MultiAllFinite(NDArrayList data, int numArrays, bool initOutput, NDArrayList @out = null)
        {
            return new Operator("multi_all_finite")
                .SetInput(data)
                .SetParam("numArrays", numArrays)
                .SetParam("initOutput", initOutput)
                .Invoke(@out);
        }

        public static NDArrayList KhatriRao(NDArrayList args, NDArrayList @out = null)
        {
            return new Operator("khatri_rao")
                .SetInput(args)
                .Invoke(@out);
        }

        public static NDArrayList Custom(NDArrayList data, string opType, NDArrayList @out = null)
        {
            return new Operator("Custom")
                .SetInput(data)
                .SetParam("opType", opType)
                .Invoke(@out);
        }

        public static NDArrayList IdentityAttachKLSparseReg(NDArray data, float sparsenessTarget, float penalty, float momentum, NDArrayList @out = null)
        {
            return new Operator("IdentityAttachKLSparseReg")
                .SetInput(data)
                .SetParam("sparsenessTarget", sparsenessTarget)
                .SetParam("penalty", penalty)
                .SetParam("momentum", momentum)
                .Invoke(@out);
        }

        public static NDArrayList LeakyReLU(NDArray data, NDArray gamma, string actType, float slope, float lowerBound, float upperBound, NDArrayList @out = null)
        {
            return new Operator("LeakyReLU")
                .SetInput(data)
                .SetInput(gamma)
                .SetParam("actType", actType)
                .SetParam("slope", slope)
                .SetParam("lowerBound", lowerBound)
                .SetParam("upperBound", upperBound)
                .Invoke(@out);
        }

        public static NDArrayList SoftmaxCrossEntropy(NDArray data, NDArray label, NDArrayList @out = null)
        {
            return new Operator("softmax_cross_entropy")
                .SetInput(data)
                .SetInput(label)
                .Invoke(@out);
        }

        public static NDArrayList Activation(NDArray data, string actType, NDArrayList @out = null)
        {
            return new Operator("Activation")
                .SetInput(data)
                .SetParam("actType", actType)
                .Invoke(@out);
        }

        public static NDArrayList BatchNorm(NDArray data, NDArray gamma, NDArray beta, NDArray movingMean, NDArray movingVar, double eps, float momentum, bool fixGamma, bool useGlobalStats, bool outputMeanVar, int axis, bool cudnnOff, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList Concat(NDArrayList data, int numArgs, int dim, NDArrayList @out = null)
        {
            return new Operator("Concat")
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("dim", dim)
                .Invoke(@out);
        }

        public static NDArrayList Convolution(NDArray data, NDArray weight, NDArray bias, Shape kernel, Shape stride, Shape dilate, Shape pad, int numFilter, int numGroup, long workspace, bool noBias, string cudnnTune, bool cudnnOff, string layout, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList CTCLoss(NDArray data, NDArray label, NDArray dataLengths, NDArray labelLengths, bool useDataLengths, bool useLabelLengths, string blankLabel, NDArrayList @out = null)
        {
            return new Operator("CTCLoss")
                .SetInput(data)
                .SetInput(label)
                .SetInput(dataLengths)
                .SetInput(labelLengths)
                .SetParam("useDataLengths", useDataLengths)
                .SetParam("useLabelLengths", useLabelLengths)
                .SetParam("blankLabel", blankLabel)
                .Invoke(@out);
        }

        public static NDArrayList Deconvolution(NDArray data, NDArray weight, NDArray bias, Shape kernel, Shape stride, Shape dilate, Shape pad, Shape adj, Shape targetShape, int numFilter, int numGroup, long workspace, bool noBias, string cudnnTune, bool cudnnOff, string layout, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList Dropout(NDArray data, float p, string mode, Shape axes, bool cudnnOff, NDArrayList @out = null)
        {
            return new Operator("Dropout")
                .SetInput(data)
                .SetParam("p", p)
                .SetParam("mode", mode)
                .SetParam("axes", axes)
                .SetParam("cudnnOff", cudnnOff)
                .Invoke(@out);
        }

        public static NDArrayList FullyConnected(NDArray data, NDArray weight, NDArray bias, int numHidden, bool noBias, bool flatten, NDArrayList @out = null)
        {
            return new Operator("FullyConnected")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("numHidden", numHidden)
                .SetParam("noBias", noBias)
                .SetParam("flatten", flatten)
                .Invoke(@out);
        }

        public static NDArrayList LayerNorm(NDArray data, NDArray gamma, NDArray beta, int axis, float eps, bool outputMeanVar, NDArrayList @out = null)
        {
            return new Operator("LayerNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("axis", axis)
                .SetParam("eps", eps)
                .SetParam("outputMeanVar", outputMeanVar)
                .Invoke(@out);
        }

        public static NDArrayList LRN(NDArray data, float alpha, float beta, float knorm, int nsize, NDArrayList @out = null)
        {
            return new Operator("LRN")
                .SetInput(data)
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetParam("knorm", knorm)
                .SetParam("nsize", nsize)
                .Invoke(@out);
        }

        public static NDArrayList Moments(NDArray data, Shape axes, bool keepdims, NDArrayList @out = null)
        {
            return new Operator("moments")
                .SetInput(data)
                .SetParam("axes", axes)
                .SetParam("keepdims", keepdims)
                .Invoke(@out);
        }

        public static NDArrayList Pooling(NDArray data, Shape kernel, string poolType, bool globalPool, bool cudnnOff, string poolingConvention, Shape stride, Shape pad, int pValue, bool countIncludePad, string layout, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList Softmax(NDArray data, int axis, double temperature, string dtype, NDArrayList @out = null)
        {
            return new Operator("softmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList Softmin(NDArray data, int axis, double temperature, string dtype, NDArrayList @out = null)
        {
            return new Operator("softmin")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList LogSoftmax(NDArray data, int axis, double temperature, string dtype, NDArrayList @out = null)
        {
            return new Operator("log_softmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList SoftmaxActivation(NDArray data, string mode, NDArrayList @out = null)
        {
            return new Operator("SoftmaxActivation")
                .SetInput(data)
                .SetParam("mode", mode)
                .Invoke(@out);
        }

        public static NDArrayList UpSampling(NDArrayList data, int scale, int numFilter, string sampleType, string multiInputMode, int numArgs, long workspace, NDArrayList @out = null)
        {
            return new Operator("UpSampling")
                .SetInput(data)
                .SetParam("scale", scale)
                .SetParam("numFilter", numFilter)
                .SetParam("sampleType", sampleType)
                .SetParam("multiInputMode", multiInputMode)
                .SetParam("numArgs", numArgs)
                .SetParam("workspace", workspace)
                .Invoke(@out);
        }

        public static NDArrayList SignsgdUpdate(NDArray weight, NDArray grad, float lr, float wd, float rescaleGrad, float clipGradient, NDArrayList @out = null)
        {
            return new Operator("signsgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .Invoke(@out);
        }

        public static NDArrayList SignumUpdate(NDArray weight, NDArray grad, NDArray mom, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, float wdLh, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList MultiSgdUpdate(NDArrayList data, object lrs, object wds, float rescaleGrad, float clipGradient, int numWeights, NDArrayList @out = null)
        {
            return new Operator("multi_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("numWeights", numWeights)
                .Invoke(@out);
        }

        public static NDArrayList MultiSgdMomUpdate(NDArrayList data, object lrs, object wds, float momentum, float rescaleGrad, float clipGradient, int numWeights, NDArrayList @out = null)
        {
            return new Operator("multi_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("numWeights", numWeights)
                .Invoke(@out);
        }

        public static NDArrayList MultiMpSgdUpdate(NDArrayList data, object lrs, object wds, float rescaleGrad, float clipGradient, int numWeights, NDArrayList @out = null)
        {
            return new Operator("multi_mp_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("numWeights", numWeights)
                .Invoke(@out);
        }

        public static NDArrayList MultiMpSgdMomUpdate(NDArrayList data, object lrs, object wds, float momentum, float rescaleGrad, float clipGradient, int numWeights, NDArrayList @out = null)
        {
            return new Operator("multi_mp_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("numWeights", numWeights)
                .Invoke(@out);
        }

        public static NDArrayList SgdUpdate(NDArray weight, NDArray grad, float lr, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, NDArrayList @out = null)
        {
            return new Operator("sgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("lazyUpdate", lazyUpdate)
                .Invoke(@out);
        }

        public static NDArrayList SgdMomUpdate(NDArray weight, NDArray grad, NDArray mom, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList MpSgdUpdate(NDArray weight, NDArray grad, NDArray weight32, float lr, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList MpSgdMomUpdate(NDArray weight, NDArray grad, NDArray mom, NDArray weight32, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList FtmlUpdate(NDArray weight, NDArray grad, NDArray d, NDArray v, NDArray z, float lr, float beta1, float beta2, double epsilon, int t, float wd, float rescaleGrad, float clipGrad, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList AdamUpdate(NDArray weight, NDArray grad, NDArray mean, NDArray var, float lr, float beta1, float beta2, float epsilon, float wd, float rescaleGrad, float clipGradient, bool lazyUpdate, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList NagMomUpdate(NDArray weight, NDArray grad, NDArray mom, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList MpNagMomUpdate(NDArray weight, NDArray grad, NDArray mom, NDArray weight32, float lr, float momentum, float wd, float rescaleGrad, float clipGradient, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList RmspropUpdate(NDArray weight, NDArray grad, NDArray n, float lr, float gamma1, float epsilon, float wd, float rescaleGrad, float clipGradient, float clipWeights, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList RmspropalexUpdate(NDArray weight, NDArray grad, NDArray n, NDArray g, NDArray delta, float lr, float gamma1, float gamma2, float epsilon, float wd, float rescaleGrad, float clipGradient, float clipWeights, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList FtrlUpdate(NDArray weight, NDArray grad, NDArray z, NDArray n, float lr, float lamda1, float beta, float wd, float rescaleGrad, float clipGradient, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList Pad(NDArray data, string mode, Shape padWidth, double constantValue, NDArrayList @out = null)
        {
            return new Operator("Pad")
                .SetInput(data)
                .SetParam("mode", mode)
                .SetParam("padWidth", padWidth)
                .SetParam("constantValue", constantValue)
                .Invoke(@out);
        }

        public static NDArrayList Flatten(NDArray data, NDArrayList @out = null)
        {
            return new Operator("Flatten")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList LinearRegressionOutput(NDArray data, NDArray label, float gradScale, NDArrayList @out = null)
        {
            return new Operator("LinearRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("gradScale", gradScale)
                .Invoke(@out);
        }

        public static NDArrayList MAERegressionOutput(NDArray data, NDArray label, float gradScale, NDArrayList @out = null)
        {
            return new Operator("MAERegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("gradScale", gradScale)
                .Invoke(@out);
        }

        public static NDArrayList LogisticRegressionOutput(NDArray data, NDArray label, float gradScale, NDArrayList @out = null)
        {
            return new Operator("LogisticRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("gradScale", gradScale)
                .Invoke(@out);
        }

        public static NDArrayList RNN(NDArray data, NDArray parameters, NDArray state, NDArray stateCell, NDArray sequenceLength, int stateSize, int numLayers, bool bidirectional, string mode, float p, bool stateOutputs, int projectionSize, double lstmStateClipMin, double lstmStateClipMax, bool lstmStateClipNan, bool useSequenceLength, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList SliceChannel(NDArray data, int numOutputs, int axis, bool squeezeAxis, NDArrayList @out = null)
        {
            return new Operator("SliceChannel")
                .SetInput(data)
                .SetParam("numOutputs", numOutputs)
                .SetParam("axis", axis)
                .SetParam("squeezeAxis", squeezeAxis)
                .Invoke(@out);
        }

        public static NDArrayList SoftmaxOutput(NDArray data, NDArray label, float gradScale, float ignoreLabel, bool multiOutput, bool useIgnore, bool preserveShape, string normalization, bool outGrad, float smoothAlpha, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList SwapAxis(NDArray data, int dim1, int dim2, NDArrayList @out = null)
        {
            return new Operator("SwapAxis")
                .SetInput(data)
                .SetParam("dim1", dim1)
                .SetParam("dim2", dim2)
                .Invoke(@out);
        }

        public static NDArrayList AmpCast(NDArray data, string dtype, NDArrayList @out = null)
        {
            return new Operator("amp_cast")
                .SetInput(data)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList AmpMulticast(NDArrayList data, int numOutputs, NDArrayList @out = null)
        {
            return new Operator("amp_multicast")
                .SetInput(data)
                .SetParam("numOutputs", numOutputs)
                .Invoke(@out);
        }

        public static NDArrayList Argmax(NDArray data, int axis, bool keepdims, NDArrayList @out = null)
        {
            return new Operator("argmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .Invoke(@out);
        }

        public static NDArrayList Argmin(NDArray data, int axis, bool keepdims, NDArrayList @out = null)
        {
            return new Operator("argmin")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .Invoke(@out);
        }

        public static NDArrayList ArgmaxChannel(NDArray data, NDArrayList @out = null)
        {
            return new Operator("argmax_channel")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Pick(NDArray data, NDArray index, int axis, bool keepdims, string mode, NDArrayList @out = null)
        {
            return new Operator("pick")
                .SetInput(data)
                .SetInput(index)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("mode", mode)
                .Invoke(@out);
        }

        public static NDArrayList Sum(NDArray data, Shape axis, bool keepdims, bool exclude, NDArrayList @out = null)
        {
            return new Operator("sum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Mean(NDArray data, Shape axis, bool keepdims, bool exclude, NDArrayList @out = null)
        {
            return new Operator("mean")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Prod(NDArray data, Shape axis, bool keepdims, bool exclude, NDArrayList @out = null)
        {
            return new Operator("prod")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Nansum(NDArray data, Shape axis, bool keepdims, bool exclude, NDArrayList @out = null)
        {
            return new Operator("nansum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Nanprod(NDArray data, Shape axis, bool keepdims, bool exclude, NDArrayList @out = null)
        {
            return new Operator("nanprod")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Max(NDArray data, Shape axis, bool keepdims, bool exclude, NDArrayList @out = null)
        {
            return new Operator("max")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Min(NDArray data, Shape axis, bool keepdims, bool exclude, NDArrayList @out = null)
        {
            return new Operator("min")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastAxis(NDArray data, Shape axis, Shape size, NDArrayList @out = null)
        {
            return new Operator("broadcast_axis")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("size", size)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastTo(NDArray data, Shape shape, NDArrayList @out = null)
        {
            return new Operator("broadcast_to")
                .SetInput(data)
                .SetParam("shape", shape)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastLike(NDArray lhs, NDArray rhs, Shape lhsAxes, Shape rhsAxes, NDArrayList @out = null)
        {
            return new Operator("broadcast_like")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("lhsAxes", lhsAxes)
                .SetParam("rhsAxes", rhsAxes)
                .Invoke(@out);
        }

        public static NDArrayList Norm(NDArray data, int ord, Shape axis, string outDtype, bool keepdims, NDArrayList @out = null)
        {
            return new Operator("norm")
                .SetInput(data)
                .SetParam("ord", ord)
                .SetParam("axis", axis)
                .SetParam("outDtype", outDtype)
                .SetParam("keepdims", keepdims)
                .Invoke(@out);
        }

        public static NDArrayList CastStorage(NDArray data, string stype, NDArrayList @out = null)
        {
            return new Operator("cast_storage")
                .SetInput(data)
                .SetParam("stype", stype)
                .Invoke(@out);
        }

        public static NDArrayList Where(NDArray condition, NDArray x, NDArray y, NDArrayList @out = null)
        {
            return new Operator("where")
                .SetInput(condition)
                .SetInput(x)
                .SetInput(y)
                .Invoke(@out);
        }

        public static NDArrayList Diag(NDArray data, int k, int axis1, int axis2, NDArrayList @out = null)
        {
            return new Operator("diag")
                .SetInput(data)
                .SetParam("k", k)
                .SetParam("axis1", axis1)
                .SetParam("axis2", axis2)
                .Invoke(@out);
        }

        public static NDArrayList Dot(NDArray lhs, NDArray rhs, bool transposea, bool transposeb, string forwardStype, NDArrayList @out = null)
        {
            return new Operator("dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transposea", transposea)
                .SetParam("transposeb", transposeb)
                .SetParam("forwardStype", forwardStype)
                .Invoke(@out);
        }

        public static NDArrayList BatchDot(NDArray lhs, NDArray rhs, bool transposea, bool transposeb, string forwardStype, NDArrayList @out = null)
        {
            return new Operator("batch_dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transposea", transposea)
                .SetParam("transposeb", transposeb)
                .SetParam("forwardStype", forwardStype)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastAdd(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastSub(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_sub")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastMul(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_mul")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastDiv(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_div")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastMod(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_mod")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastPower(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_power")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastMaximum(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_maximum")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastMinimum(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_minimum")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastHypot(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_hypot")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastEqual(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastNotEqual(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_not_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastGreater(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_greater")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastGreaterEqual(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_greater_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastLesser(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_lesser")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastLesserEqual(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_lesser_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastLogicalAnd(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_logical_and")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastLogicalOr(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_logical_or")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastLogicalXor(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("broadcast_logical_xor")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList ElemwiseAdd(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("elemwise_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList ElemwiseSub(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("elemwise_sub")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList ElemwiseMul(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("elemwise_mul")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList ElemwiseDiv(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("elemwise_div")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList SmoothL1(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("smooth_l1")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList Addn(NDArrayList args, NDArrayList @out = null)
        {
            return new Operator("add_n")
                .SetInput(args)
                .Invoke(@out);
        }

        public static NDArrayList Relu(NDArray data, NDArrayList @out = null)
        {
            return new Operator("relu")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Sigmoid(NDArray data, NDArrayList @out = null)
        {
            return new Operator("sigmoid")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList HardSigmoid(NDArray data, float alpha, float beta, NDArrayList @out = null)
        {
            return new Operator("hard_sigmoid")
                .SetInput(data)
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .Invoke(@out);
        }

        public static NDArrayList Softsign(NDArray data, NDArrayList @out = null)
        {
            return new Operator("softsign")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList BlockGrad(NDArray data, NDArrayList @out = null)
        {
            return new Operator("BlockGrad")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList MakeLoss(NDArray data, NDArrayList @out = null)
        {
            return new Operator("make_loss")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList ReshapeLike(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("reshape_like")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList ShapeArray(NDArray data, int lhsBegin, int lhsEnd, int rhsBegin, int rhsEnd, NDArrayList @out = null)
        {
            return new Operator("shape_array")
                .SetInput(data)
                .SetParam("lhsBegin", lhsBegin)
                .SetParam("lhsEnd", lhsEnd)
                .SetParam("rhsBegin", rhsBegin)
                .SetParam("rhsEnd", rhsEnd)
                .Invoke(@out);
        }

        public static NDArrayList SizeArray(NDArray data, NDArrayList @out = null)
        {
            return new Operator("size_array")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Cast(NDArray data, string dtype, NDArrayList @out = null)
        {
            return new Operator("Cast")
                .SetInput(data)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList Negative(NDArray data, NDArrayList @out = null)
        {
            return new Operator("negative")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Reciprocal(NDArray data, NDArrayList @out = null)
        {
            return new Operator("reciprocal")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Abs(NDArray data, NDArrayList @out = null)
        {
            return new Operator("abs")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Sign(NDArray data, NDArrayList @out = null)
        {
            return new Operator("sign")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Round(NDArray data, NDArrayList @out = null)
        {
            return new Operator("round")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Rint(NDArray data, NDArrayList @out = null)
        {
            return new Operator("rint")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Ceil(NDArray data, NDArrayList @out = null)
        {
            return new Operator("ceil")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Floor(NDArray data, NDArrayList @out = null)
        {
            return new Operator("floor")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Trunc(NDArray data, NDArrayList @out = null)
        {
            return new Operator("trunc")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Fix(NDArray data, NDArrayList @out = null)
        {
            return new Operator("fix")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Square(NDArray data, NDArrayList @out = null)
        {
            return new Operator("square")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Sqrt(NDArray data, NDArrayList @out = null)
        {
            return new Operator("sqrt")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Rsqrt(NDArray data, NDArrayList @out = null)
        {
            return new Operator("rsqrt")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Cbrt(NDArray data, NDArrayList @out = null)
        {
            return new Operator("cbrt")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Erf(NDArray data, NDArrayList @out = null)
        {
            return new Operator("erf")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Erfinv(NDArray data, NDArrayList @out = null)
        {
            return new Operator("erfinv")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Rcbrt(NDArray data, NDArrayList @out = null)
        {
            return new Operator("rcbrt")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Exp(NDArray data, NDArrayList @out = null)
        {
            return new Operator("exp")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Log(NDArray data, NDArrayList @out = null)
        {
            return new Operator("log")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Log10(NDArray data, NDArrayList @out = null)
        {
            return new Operator("log10")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Log2(NDArray data, NDArrayList @out = null)
        {
            return new Operator("log2")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Log1p(NDArray data, NDArrayList @out = null)
        {
            return new Operator("log1p")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Expm1(NDArray data, NDArrayList @out = null)
        {
            return new Operator("expm1")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Gamma(NDArray data, NDArrayList @out = null)
        {
            return new Operator("gamma")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Gammaln(NDArray data, NDArrayList @out = null)
        {
            return new Operator("gammaln")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList LogicalNot(NDArray data, NDArrayList @out = null)
        {
            return new Operator("logical_not")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Sin(NDArray data, NDArrayList @out = null)
        {
            return new Operator("sin")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Cos(NDArray data, NDArrayList @out = null)
        {
            return new Operator("cos")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Tan(NDArray data, NDArrayList @out = null)
        {
            return new Operator("tan")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Arcsin(NDArray data, NDArrayList @out = null)
        {
            return new Operator("arcsin")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Arccos(NDArray data, NDArrayList @out = null)
        {
            return new Operator("arccos")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Arctan(NDArray data, NDArrayList @out = null)
        {
            return new Operator("arctan")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Degrees(NDArray data, NDArrayList @out = null)
        {
            return new Operator("degrees")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Radians(NDArray data, NDArrayList @out = null)
        {
            return new Operator("radians")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Sinh(NDArray data, NDArrayList @out = null)
        {
            return new Operator("sinh")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Cosh(NDArray data, NDArrayList @out = null)
        {
            return new Operator("cosh")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Tanh(NDArray data, NDArrayList @out = null)
        {
            return new Operator("tanh")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Arcsinh(NDArray data, NDArrayList @out = null)
        {
            return new Operator("arcsinh")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Arccosh(NDArray data, NDArrayList @out = null)
        {
            return new Operator("arccosh")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Arctanh(NDArray data, NDArrayList @out = null)
        {
            return new Operator("arctanh")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Embedding(NDArray data, NDArray weight, int inputDim, int outputDim, string dtype, bool sparseGrad, NDArrayList @out = null)
        {
            return new Operator("Embedding")
                .SetInput(data)
                .SetInput(weight)
                .SetParam("inputDim", inputDim)
                .SetParam("outputDim", outputDim)
                .SetParam("dtype", dtype)
                .SetParam("sparseGrad", sparseGrad)
                .Invoke(@out);
        }

        public static NDArrayList Take(NDArray a, NDArray indices, int axis, string mode, NDArrayList @out = null)
        {
            return new Operator("take")
                .SetInput(a)
                .SetInput(indices)
                .SetParam("axis", axis)
                .SetParam("mode", mode)
                .Invoke(@out);
        }

        public static NDArrayList BatchTake(NDArray a, NDArray indices, NDArrayList @out = null)
        {
            return new Operator("batch_take")
                .SetInput(a)
                .SetInput(indices)
                .Invoke(@out);
        }

        public static NDArrayList OneHot(NDArray indices, int depth, double onValue, double offValue, string dtype, NDArrayList @out = null)
        {
            return new Operator("one_hot")
                .SetInput(indices)
                .SetParam("depth", depth)
                .SetParam("onValue", onValue)
                .SetParam("offValue", offValue)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList GatherNd(NDArray data, NDArray indices, NDArrayList @out = null)
        {
            return new Operator("gather_nd")
                .SetInput(data)
                .SetInput(indices)
                .Invoke(@out);
        }

        public static NDArrayList ScatterNd(NDArray data, NDArray indices, Shape shape, NDArrayList @out = null)
        {
            return new Operator("scatter_nd")
                .SetInput(data)
                .SetInput(indices)
                .SetParam("shape", shape)
                .Invoke(@out);
        }

        public static NDArrayList ZerosLike(NDArray data, NDArrayList @out = null)
        {
            return new Operator("zeros_like")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList OnesLike(NDArray data, NDArrayList @out = null)
        {
            return new Operator("ones_like")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList Reshape(NDArray data, Shape shape, bool reverse, Shape targetShape, bool keepHighest, NDArrayList @out = null)
        {
            return new Operator("Reshape")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("reverse", reverse)
                .SetParam("targetShape", targetShape)
                .SetParam("keepHighest", keepHighest)
                .Invoke(@out);
        }

        public static NDArrayList Transpose(NDArray data, Shape axes, NDArrayList @out = null)
        {
            return new Operator("transpose")
                .SetInput(data)
                .SetParam("axes", axes)
                .Invoke(@out);
        }

        public static NDArrayList ExpandDims(NDArray data, int axis, NDArrayList @out = null)
        {
            return new Operator("expand_dims")
                .SetInput(data)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList Slice(NDArray data, Shape begin, Shape end, Shape step, NDArrayList @out = null)
        {
            return new Operator("slice")
                .SetInput(data)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetParam("step", step)
                .Invoke(@out);
        }

        public static NDArrayList SliceAxis(NDArray data, int axis, int begin, int end, NDArrayList @out = null)
        {
            return new Operator("slice_axis")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .Invoke(@out);
        }

        public static NDArrayList SliceLike(NDArray data, NDArray shapeLike, Shape axes, NDArrayList @out = null)
        {
            return new Operator("slice_like")
                .SetInput(data)
                .SetInput(shapeLike)
                .SetParam("axes", axes)
                .Invoke(@out);
        }

        public static NDArrayList Clip(NDArray data, float aMin, float aMax, NDArrayList @out = null)
        {
            return new Operator("clip")
                .SetInput(data)
                .SetParam("aMin", aMin)
                .SetParam("aMax", aMax)
                .Invoke(@out);
        }

        public static NDArrayList Repeat(NDArray data, int repeats, int axis, NDArrayList @out = null)
        {
            return new Operator("repeat")
                .SetInput(data)
                .SetParam("repeats", repeats)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList Tile(NDArray data, Shape reps, NDArrayList @out = null)
        {
            return new Operator("tile")
                .SetInput(data)
                .SetParam("reps", reps)
                .Invoke(@out);
        }

        public static NDArrayList Reverse(NDArray data, Shape axis, NDArrayList @out = null)
        {
            return new Operator("reverse")
                .SetInput(data)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList Stack(NDArrayList data, int axis, int numArgs, NDArrayList @out = null)
        {
            return new Operator("stack")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("numArgs", numArgs)
                .Invoke(@out);
        }

        public static NDArrayList Squeeze(NDArrayList data, Shape axis, NDArrayList @out = null)
        {
            return new Operator("squeeze")
                .SetInput(data)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList DepthToSpace(NDArray data, int blockSize, NDArrayList @out = null)
        {
            return new Operator("depth_to_space")
                .SetInput(data)
                .SetParam("blockSize", blockSize)
                .Invoke(@out);
        }

        public static NDArrayList SpaceToDepth(NDArray data, int blockSize, NDArrayList @out = null)
        {
            return new Operator("space_to_depth")
                .SetInput(data)
                .SetParam("blockSize", blockSize)
                .Invoke(@out);
        }

        public static NDArrayList Topk(NDArray data, int axis, int k, string retTyp, bool isAscend, string dtype, NDArrayList @out = null)
        {
            return new Operator("topk")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("k", k)
                .SetParam("retTyp", retTyp)
                .SetParam("isAscend", isAscend)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList Sort(NDArray data, int axis, bool isAscend, NDArrayList @out = null)
        {
            return new Operator("sort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("isAscend", isAscend)
                .Invoke(@out);
        }

        public static NDArrayList Argsort(NDArray data, int axis, bool isAscend, string dtype, NDArrayList @out = null)
        {
            return new Operator("argsort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("isAscend", isAscend)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList BilinearSampler(NDArray data, NDArray grid, bool cudnnOff, NDArrayList @out = null)
        {
            return new Operator("BilinearSampler")
                .SetInput(data)
                .SetInput(grid)
                .SetParam("cudnnOff", cudnnOff)
                .Invoke(@out);
        }

        public static NDArrayList ConvolutionV1(NDArray data, NDArray weight, NDArray bias, Shape kernel, Shape stride, Shape dilate, Shape pad, int numFilter, int numGroup, long workspace, bool noBias, string cudnnTune, bool cudnnOff, string layout, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList Correlation(NDArray data1, NDArray data2, int kernelSize, int maxDisplacement, int stride1, int stride2, int padSize, bool isMultiply, NDArrayList @out = null)
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
                .Invoke(@out);
        }

        public static NDArrayList Crop(SymbolList data, int numArgs, Shape offset, Shape hw, bool centerCrop, NDArrayList @out = null)
        {
            return new Operator("Crop")
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("offset", offset)
                .SetParam("hw", hw)
                .SetParam("centerCrop", centerCrop)
                .Invoke(@out);
        }

        public static NDArrayList GridGenerator(NDArray data, string transformType, Shape targetShape, NDArrayList @out = null)
        {
            return new Operator("GridGenerator")
                .SetInput(data)
                .SetParam("transformType", transformType)
                .SetParam("targetShape", targetShape)
                .Invoke(@out);
        }

        public static NDArrayList InstanceNorm(NDArray data, NDArray gamma, NDArray beta, float eps, NDArrayList @out = null)
        {
            return new Operator("InstanceNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("eps", eps)
                .Invoke(@out);
        }

        public static NDArrayList L2Normalization(NDArray data, float eps, string mode, NDArrayList @out = null)
        {
            return new Operator("L2Normalization")
                .SetInput(data)
                .SetParam("eps", eps)
                .SetParam("mode", mode)
                .Invoke(@out);
        }

        public static NDArrayList MakeLoss(NDArray data, float gradScale, float validThresh, string normalization, NDArrayList @out = null)
        {
            return new Operator("MakeLoss")
                .SetInput(data)
                .SetParam("gradScale", gradScale)
                .SetParam("validThresh", validThresh)
                .SetParam("normalization", normalization)
                .Invoke(@out);
        }

        public static NDArrayList PoolingV1(NDArray data, Shape kernel, string poolType, bool globalPool, string poolingConvention, Shape stride, Shape pad, NDArrayList @out = null)
        {
            return new Operator("Pooling_v1")
                .SetInput(data)
                .SetParam("kernel", kernel)
                .SetParam("poolType", poolType)
                .SetParam("globalPool", globalPool)
                .SetParam("poolingConvention", poolingConvention)
                .SetParam("stride", stride)
                .SetParam("pad", pad)
                .Invoke(@out);
        }

        public static NDArrayList ROIPooling(NDArray data, NDArray rois, Shape pooledSize, float spatialScale, NDArrayList @out = null)
        {
            return new Operator("ROIPooling")
                .SetInput(data)
                .SetInput(rois)
                .SetParam("pooledSize", pooledSize)
                .SetParam("spatialScale", spatialScale)
                .Invoke(@out);
        }

        public static NDArrayList SequenceLast(NDArray data, NDArray sequenceLength, bool useSequenceLength, int axis, NDArrayList @out = null)
        {
            return new Operator("SequenceLast")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("useSequenceLength", useSequenceLength)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList SequenceMask(NDArray data, NDArray sequenceLength, bool useSequenceLength, float value, int axis, NDArrayList @out = null)
        {
            return new Operator("SequenceMask")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("useSequenceLength", useSequenceLength)
                .SetParam("value", value)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList SequenceReverse(NDArray data, NDArray sequenceLength, bool useSequenceLength, int axis, NDArrayList @out = null)
        {
            return new Operator("SequenceReverse")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("useSequenceLength", useSequenceLength)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList SpatialTransformer(NDArray data, NDArray loc, Shape targetShape, string transformType, string samplerType, bool cudnnOff, NDArrayList @out = null)
        {
            return new Operator("SpatialTransformer")
                .SetInput(data)
                .SetInput(loc)
                .SetParam("targetShape", targetShape)
                .SetParam("transformType", transformType)
                .SetParam("samplerType", samplerType)
                .SetParam("cudnnOff", cudnnOff)
                .Invoke(@out);
        }

        public static NDArrayList SVMOutput(NDArray data, NDArray label, float margin, float regularizationCoefficient, bool useLinear, NDArrayList @out = null)
        {
            return new Operator("SVMOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("margin", margin)
                .SetParam("regularizationCoefficient", regularizationCoefficient)
                .SetParam("useLinear", useLinear)
                .Invoke(@out);
        }

        public static NDArrayList FillElement0index(NDArray lhs, NDArray mhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("fill_element_0index")
                .SetInput(lhs)
                .SetInput(mhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        }
    }
}
