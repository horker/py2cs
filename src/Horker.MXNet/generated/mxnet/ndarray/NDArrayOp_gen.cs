using System;
using Horker.MXNet;
using Horker.MXNet.Interop;

namespace Horker.MXNet
{
    public partial class NDArray : NDArrayBase
    {
        public static class Op
        {
        public static NDArrayList BatchNormV1(NDArray data, NDArray gamma, NDArray beta, float? eps = null, float? momentum = null, bool fixGamma = true, bool useGlobalStats = false, bool outputMeanVar = false, NDArrayList @out = null)
        {
            return new Operator("BatchNorm_v1")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("eps", eps)
                .SetParam("momentum", momentum)
                .SetParam("fix_gamma", fixGamma)
                .SetParam("use_global_stats", useGlobalStats)
                .SetParam("output_mean_var", outputMeanVar)
                .Invoke(@out);
        }

        public static NDArrayList AllFinite(NDArray data, bool initOutput = true, NDArrayList @out = null)
        {
            return new Operator("all_finite")
                .SetInput(data)
                .SetParam("init_output", initOutput)
                .Invoke(@out);
        }

        public static NDArrayList MultiAllFinite(NDArrayList data, int? numArrays = null, bool initOutput = true, NDArrayList @out = null)
        {
            return new Operator("multi_all_finite")
                .SetInput(data)
                .SetParam("num_arrays", numArrays)
                .SetParam("init_output", initOutput)
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
                .SetParam("op_type", opType)
                .Invoke(@out);
        }

        public static NDArrayList IdentityAttachKLSparseReg(NDArray data, float? sparsenessTarget = null, float? penalty = null, float? momentum = null, NDArrayList @out = null)
        {
            return new Operator("IdentityAttachKLSparseReg")
                .SetInput(data)
                .SetParam("sparseness_target", sparsenessTarget)
                .SetParam("penalty", penalty)
                .SetParam("momentum", momentum)
                .Invoke(@out);
        }

        public static NDArrayList LeakyReLU(NDArray data, NDArray gamma, string actType = "leaky", float? slope = null, float? lowerBound = null, float? upperBound = null, NDArrayList @out = null)
        {
            return new Operator("LeakyReLU")
                .SetInput(data)
                .SetInput(gamma)
                .SetParam("act_type", actType)
                .SetParam("slope", slope)
                .SetParam("lower_bound", lowerBound)
                .SetParam("upper_bound", upperBound)
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
                .SetParam("act_type", actType)
                .Invoke(@out);
        }

        public static NDArrayList BatchNorm(NDArray data, NDArray gamma, NDArray beta, NDArray movingMean, NDArray movingVar, double? eps = null, float? momentum = null, bool fixGamma = true, bool useGlobalStats = false, bool outputMeanVar = false, int? axis = null, bool cudnnOff = false, NDArrayList @out = null)
        {
            return new Operator("BatchNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetInput(movingMean)
                .SetInput(movingVar)
                .SetParam("eps", eps)
                .SetParam("momentum", momentum)
                .SetParam("fix_gamma", fixGamma)
                .SetParam("use_global_stats", useGlobalStats)
                .SetParam("output_mean_var", outputMeanVar)
                .SetParam("axis", axis)
                .SetParam("cudnn_off", cudnnOff)
                .Invoke(@out);
        }

        public static NDArrayList Concat(NDArrayList data, int numArgs, int? dim = null, NDArrayList @out = null)
        {
            return new Operator("Concat")
                .SetInput(data)
                .SetParam("num_args", numArgs)
                .SetParam("dim", dim)
                .Invoke(@out);
        }

        public static NDArrayList Convolution(NDArray data, NDArray weight, NDArray bias, Shape kernel, Shape stride = null, Shape dilate = null, Shape pad = null, int? numFilter = null, int? numGroup = null, long? workspace = null, bool noBias = false, string cudnnTune = "None", bool cudnnOff = false, string layout = "None", NDArrayList @out = null)
        {
            stride = new Shape();
            dilate = new Shape();
            pad = new Shape();
            return new Operator("Convolution")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("kernel", kernel)
                .SetParam("stride", stride)
                .SetParam("dilate", dilate)
                .SetParam("pad", pad)
                .SetParam("num_filter", numFilter)
                .SetParam("num_group", numGroup)
                .SetParam("workspace", workspace)
                .SetParam("no_bias", noBias)
                .SetParam("cudnn_tune", cudnnTune)
                .SetParam("cudnn_off", cudnnOff)
                .SetParam("layout", layout)
                .Invoke(@out);
        }

        public static NDArrayList CTCLoss(NDArray data, NDArray label, NDArray dataLengths, NDArray labelLengths, bool useDataLengths = false, bool useLabelLengths = false, string blankLabel = "first", NDArrayList @out = null)
        {
            return new Operator("CTCLoss")
                .SetInput(data)
                .SetInput(label)
                .SetInput(dataLengths)
                .SetInput(labelLengths)
                .SetParam("use_data_lengths", useDataLengths)
                .SetParam("use_label_lengths", useLabelLengths)
                .SetParam("blank_label", blankLabel)
                .Invoke(@out);
        }

        public static NDArrayList Deconvolution(NDArray data, NDArray weight, NDArray bias, Shape kernel, Shape stride = null, Shape dilate = null, Shape pad = null, Shape adj = null, Shape targetShape = null, int? numFilter = null, int? numGroup = null, long? workspace = null, bool noBias = true, string cudnnTune = "None", bool cudnnOff = false, string layout = "None", NDArrayList @out = null)
        {
            stride = new Shape();
            dilate = new Shape();
            pad = new Shape();
            adj = new Shape();
            targetShape = new Shape();
            return new Operator("Deconvolution")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("kernel", kernel)
                .SetParam("stride", stride)
                .SetParam("dilate", dilate)
                .SetParam("pad", pad)
                .SetParam("adj", adj)
                .SetParam("target_shape", targetShape)
                .SetParam("num_filter", numFilter)
                .SetParam("num_group", numGroup)
                .SetParam("workspace", workspace)
                .SetParam("no_bias", noBias)
                .SetParam("cudnn_tune", cudnnTune)
                .SetParam("cudnn_off", cudnnOff)
                .SetParam("layout", layout)
                .Invoke(@out);
        }

        public static NDArrayList Dropout(NDArray data, float? p = null, string mode = "training", Shape axes = null, bool cudnnOff = false, NDArrayList @out = null)
        {
            axes = new Shape();
            return new Operator("Dropout")
                .SetInput(data)
                .SetParam("p", p)
                .SetParam("mode", mode)
                .SetParam("axes", axes)
                .SetParam("cudnn_off", cudnnOff)
                .Invoke(@out);
        }

        public static NDArrayList FullyConnected(NDArray data, NDArray weight, NDArray bias, int numHidden, bool noBias = false, bool flatten = true, NDArrayList @out = null)
        {
            return new Operator("FullyConnected")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("num_hidden", numHidden)
                .SetParam("no_bias", noBias)
                .SetParam("flatten", flatten)
                .Invoke(@out);
        }

        public static NDArrayList LayerNorm(NDArray data, NDArray gamma, NDArray beta, int? axis = null, float? eps = null, bool outputMeanVar = false, NDArrayList @out = null)
        {
            return new Operator("LayerNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("axis", axis)
                .SetParam("eps", eps)
                .SetParam("output_mean_var", outputMeanVar)
                .Invoke(@out);
        }

        public static NDArrayList LRN(NDArray data, float? alpha = null, float? beta = null, float? knorm = null, int? nsize = null, NDArrayList @out = null)
        {
            return new Operator("LRN")
                .SetInput(data)
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetParam("knorm", knorm)
                .SetParam("nsize", nsize)
                .Invoke(@out);
        }

        public static NDArrayList Moments(NDArray data, Shape axes = null, bool keepdims = false, NDArrayList @out = null)
        {
            return new Operator("moments")
                .SetInput(data)
                .SetParam("axes", axes)
                .SetParam("keepdims", keepdims)
                .Invoke(@out);
        }

        public static NDArrayList Pooling(NDArray data, Shape kernel = null, string poolType = "max", bool globalPool = false, bool cudnnOff = false, string poolingConvention = "valid", Shape stride = null, Shape pad = null, int? pValue = null, bool? countIncludePad = null, string layout = "None", NDArrayList @out = null)
        {
            kernel = new Shape();
            stride = new Shape();
            pad = new Shape();
            return new Operator("Pooling")
                .SetInput(data)
                .SetParam("kernel", kernel)
                .SetParam("pool_type", poolType)
                .SetParam("global_pool", globalPool)
                .SetParam("cudnn_off", cudnnOff)
                .SetParam("pooling_convention", poolingConvention)
                .SetParam("stride", stride)
                .SetParam("pad", pad)
                .SetParam("p_value", pValue)
                .SetParam("count_include_pad", countIncludePad)
                .SetParam("layout", layout)
                .Invoke(@out);
        }

        public static NDArrayList Softmax(NDArray data, int? axis = null, double? temperature = null, string dtype = "None", NDArrayList @out = null)
        {
            return new Operator("softmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList Softmin(NDArray data, int? axis = null, double? temperature = null, string dtype = "None", NDArrayList @out = null)
        {
            return new Operator("softmin")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList LogSoftmax(NDArray data, int? axis = null, double? temperature = null, string dtype = "None", NDArrayList @out = null)
        {
            return new Operator("log_softmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList SoftmaxActivation(NDArray data, string mode = "instance", NDArrayList @out = null)
        {
            return new Operator("SoftmaxActivation")
                .SetInput(data)
                .SetParam("mode", mode)
                .Invoke(@out);
        }

        public static NDArrayList UpSampling(NDArrayList data, int scale, int? numFilter = null, string sampleType = "null", string multiInputMode = "concat", int? numArgs = null, long? workspace = null, NDArrayList @out = null)
        {
            return new Operator("UpSampling")
                .SetInput(data)
                .SetParam("scale", scale)
                .SetParam("num_filter", numFilter)
                .SetParam("sample_type", sampleType)
                .SetParam("multi_input_mode", multiInputMode)
                .SetParam("num_args", numArgs)
                .SetParam("workspace", workspace)
                .Invoke(@out);
        }

        public static NDArrayList SignsgdUpdate(NDArray weight, NDArray grad, float lr, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, NDArrayList @out = null)
        {
            return new Operator("signsgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .Invoke(@out);
        }

        public static NDArrayList SignumUpdate(NDArray weight, NDArray grad, NDArray mom, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, float? wdLh = null, NDArrayList @out = null)
        {
            return new Operator("signum_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("wd_lh", wdLh)
                .Invoke(@out);
        }

        public static NDArrayList MultiSgdUpdate(NDArrayList data, object lrs, object wds, float? rescaleGrad = null, float? clipGradient = null, int? numWeights = null, NDArrayList @out = null)
        {
            return new Operator("multi_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("num_weights", numWeights)
                .Invoke(@out);
        }

        public static NDArrayList MultiSgdMomUpdate(NDArrayList data, object lrs, object wds, float? momentum = null, float? rescaleGrad = null, float? clipGradient = null, int? numWeights = null, NDArrayList @out = null)
        {
            return new Operator("multi_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("num_weights", numWeights)
                .Invoke(@out);
        }

        public static NDArrayList MultiMpSgdUpdate(NDArrayList data, object lrs, object wds, float? rescaleGrad = null, float? clipGradient = null, int? numWeights = null, NDArrayList @out = null)
        {
            return new Operator("multi_mp_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("num_weights", numWeights)
                .Invoke(@out);
        }

        public static NDArrayList MultiMpSgdMomUpdate(NDArrayList data, object lrs, object wds, float? momentum = null, float? rescaleGrad = null, float? clipGradient = null, int? numWeights = null, NDArrayList @out = null)
        {
            return new Operator("multi_mp_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("num_weights", numWeights)
                .Invoke(@out);
        }

        public static NDArrayList SgdUpdate(NDArray weight, NDArray grad, float lr, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, NDArrayList @out = null)
        {
            return new Operator("sgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("lazy_update", lazyUpdate)
                .Invoke(@out);
        }

        public static NDArrayList SgdMomUpdate(NDArray weight, NDArray grad, NDArray mom, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, NDArrayList @out = null)
        {
            return new Operator("sgd_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("lazy_update", lazyUpdate)
                .Invoke(@out);
        }

        public static NDArrayList MpSgdUpdate(NDArray weight, NDArray grad, NDArray weight32, float lr, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, NDArrayList @out = null)
        {
            return new Operator("mp_sgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(weight32)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("lazy_update", lazyUpdate)
                .Invoke(@out);
        }

        public static NDArrayList MpSgdMomUpdate(NDArray weight, NDArray grad, NDArray mom, NDArray weight32, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, NDArrayList @out = null)
        {
            return new Operator("mp_sgd_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetInput(weight32)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("lazy_update", lazyUpdate)
                .Invoke(@out);
        }

        public static NDArrayList FtmlUpdate(NDArray weight, NDArray grad, NDArray d, NDArray v, NDArray z, float lr, float? beta1 = null, float? beta2 = null, double? epsilon = null, int? t = null, float? wd = null, float? rescaleGrad = null, float? clipGrad = null, NDArrayList @out = null)
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
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_grad", clipGrad)
                .Invoke(@out);
        }

        public static NDArrayList AdamUpdate(NDArray weight, NDArray grad, NDArray mean, NDArray var, float lr, float? beta1 = null, float? beta2 = null, float? epsilon = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, NDArrayList @out = null)
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
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("lazy_update", lazyUpdate)
                .Invoke(@out);
        }

        public static NDArrayList NagMomUpdate(NDArray weight, NDArray grad, NDArray mom, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, NDArrayList @out = null)
        {
            return new Operator("nag_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .Invoke(@out);
        }

        public static NDArrayList MpNagMomUpdate(NDArray weight, NDArray grad, NDArray mom, NDArray weight32, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, NDArrayList @out = null)
        {
            return new Operator("mp_nag_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetInput(weight32)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .Invoke(@out);
        }

        public static NDArrayList RmspropUpdate(NDArray weight, NDArray grad, NDArray n, float lr, float? gamma1 = null, float? epsilon = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, float? clipWeights = null, NDArrayList @out = null)
        {
            return new Operator("rmsprop_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(n)
                .SetParam("lr", lr)
                .SetParam("gamma1", gamma1)
                .SetParam("epsilon", epsilon)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("clip_weights", clipWeights)
                .Invoke(@out);
        }

        public static NDArrayList RmspropalexUpdate(NDArray weight, NDArray grad, NDArray n, NDArray g, NDArray delta, float lr, float? gamma1 = null, float? gamma2 = null, float? epsilon = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, float? clipWeights = null, NDArrayList @out = null)
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
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("clip_weights", clipWeights)
                .Invoke(@out);
        }

        public static NDArrayList FtrlUpdate(NDArray weight, NDArray grad, NDArray z, NDArray n, float lr, float? lamda1 = null, float? beta = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, NDArrayList @out = null)
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
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .Invoke(@out);
        }

        public static NDArrayList Pad(NDArray data, string mode, Shape padWidth, double? constantValue = null, NDArrayList @out = null)
        {
            return new Operator("Pad")
                .SetInput(data)
                .SetParam("mode", mode)
                .SetParam("pad_width", padWidth)
                .SetParam("constant_value", constantValue)
                .Invoke(@out);
        }

        public static NDArrayList Flatten(NDArray data, NDArrayList @out = null)
        {
            return new Operator("Flatten")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList LinearRegressionOutput(NDArray data, NDArray label, float? gradScale = null, NDArrayList @out = null)
        {
            return new Operator("LinearRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", gradScale)
                .Invoke(@out);
        }

        public static NDArrayList MAERegressionOutput(NDArray data, NDArray label, float? gradScale = null, NDArrayList @out = null)
        {
            return new Operator("MAERegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", gradScale)
                .Invoke(@out);
        }

        public static NDArrayList LogisticRegressionOutput(NDArray data, NDArray label, float? gradScale = null, NDArrayList @out = null)
        {
            return new Operator("LogisticRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", gradScale)
                .Invoke(@out);
        }

        public static NDArrayList RNN(NDArray data, NDArray parameters, NDArray state, NDArray stateCell, NDArray sequenceLength, int stateSize, int numLayers, bool bidirectional = false, string mode = "null", float? p = null, bool stateOutputs = false, int? projectionSize = null, double? lstmStateClipMin = null, double? lstmStateClipMax = null, bool lstmStateClipNan = false, bool useSequenceLength = false, NDArrayList @out = null)
        {
            return new Operator("RNN")
                .SetInput(data)
                .SetInput(parameters)
                .SetInput(state)
                .SetInput(stateCell)
                .SetInput(sequenceLength)
                .SetParam("state_size", stateSize)
                .SetParam("num_layers", numLayers)
                .SetParam("bidirectional", bidirectional)
                .SetParam("mode", mode)
                .SetParam("p", p)
                .SetParam("state_outputs", stateOutputs)
                .SetParam("projection_size", projectionSize)
                .SetParam("lstm_state_clip_min", lstmStateClipMin)
                .SetParam("lstm_state_clip_max", lstmStateClipMax)
                .SetParam("lstm_state_clip_nan", lstmStateClipNan)
                .SetParam("use_sequence_length", useSequenceLength)
                .Invoke(@out);
        }

        public static NDArrayList SliceChannel(NDArray data, int numOutputs, int? axis = null, bool squeezeAxis = false, NDArrayList @out = null)
        {
            return new Operator("SliceChannel")
                .SetInput(data)
                .SetParam("num_outputs", numOutputs)
                .SetParam("axis", axis)
                .SetParam("squeeze_axis", squeezeAxis)
                .Invoke(@out);
        }

        public static NDArrayList SoftmaxOutput(NDArray data, NDArray label, float? gradScale = null, float? ignoreLabel = null, bool multiOutput = false, bool useIgnore = false, bool preserveShape = false, string normalization = "null", bool outGrad = false, float? smoothAlpha = null, NDArrayList @out = null)
        {
            return new Operator("SoftmaxOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", gradScale)
                .SetParam("ignore_label", ignoreLabel)
                .SetParam("multi_output", multiOutput)
                .SetParam("use_ignore", useIgnore)
                .SetParam("preserve_shape", preserveShape)
                .SetParam("normalization", normalization)
                .SetParam("out_grad", outGrad)
                .SetParam("smooth_alpha", smoothAlpha)
                .Invoke(@out);
        }

        public static NDArrayList SwapAxis(NDArray data, int? dim1 = null, int? dim2 = null, NDArrayList @out = null)
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
                .SetParam("num_outputs", numOutputs)
                .Invoke(@out);
        }

        public static NDArrayList Argmax(NDArray data, int? axis = null, bool keepdims = false, NDArrayList @out = null)
        {
            return new Operator("argmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .Invoke(@out);
        }

        public static NDArrayList Argmin(NDArray data, int? axis = null, bool keepdims = false, NDArrayList @out = null)
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

        public static NDArrayList Pick(NDArray data, NDArray index, int? axis = null, bool keepdims = false, string mode = "clip", NDArrayList @out = null)
        {
            return new Operator("pick")
                .SetInput(data)
                .SetInput(index)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("mode", mode)
                .Invoke(@out);
        }

        public static NDArrayList Sum(NDArray data, Shape axis = null, bool keepdims = false, bool exclude = false, NDArrayList @out = null)
        {
            return new Operator("sum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Mean(NDArray data, Shape axis = null, bool keepdims = false, bool exclude = false, NDArrayList @out = null)
        {
            return new Operator("mean")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Prod(NDArray data, Shape axis = null, bool keepdims = false, bool exclude = false, NDArrayList @out = null)
        {
            return new Operator("prod")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Nansum(NDArray data, Shape axis = null, bool keepdims = false, bool exclude = false, NDArrayList @out = null)
        {
            return new Operator("nansum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Nanprod(NDArray data, Shape axis = null, bool keepdims = false, bool exclude = false, NDArrayList @out = null)
        {
            return new Operator("nanprod")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Max(NDArray data, Shape axis = null, bool keepdims = false, bool exclude = false, NDArrayList @out = null)
        {
            return new Operator("max")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList Min(NDArray data, Shape axis = null, bool keepdims = false, bool exclude = false, NDArrayList @out = null)
        {
            return new Operator("min")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastAxis(NDArray data, Shape axis = null, Shape size = null, NDArrayList @out = null)
        {
            axis = new Shape();
            size = new Shape();
            return new Operator("broadcast_axis")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("size", size)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastTo(NDArray data, Shape shape = null, NDArrayList @out = null)
        {
            shape = new Shape();
            return new Operator("broadcast_to")
                .SetInput(data)
                .SetParam("shape", shape)
                .Invoke(@out);
        }

        public static NDArrayList BroadcastLike(NDArray lhs, NDArray rhs, Shape lhsAxes = null, Shape rhsAxes = null, NDArrayList @out = null)
        {
            return new Operator("broadcast_like")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("lhs_axes", lhsAxes)
                .SetParam("rhs_axes", rhsAxes)
                .Invoke(@out);
        }

        public static NDArrayList Norm(NDArray data, int? ord = null, Shape axis = null, string outDtype = "None", bool keepdims = false, NDArrayList @out = null)
        {
            return new Operator("norm")
                .SetInput(data)
                .SetParam("ord", ord)
                .SetParam("axis", axis)
                .SetParam("out_dtype", outDtype)
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

        public static NDArrayList Diag(NDArray data, int? k = null, int? axis1 = null, int? axis2 = null, NDArrayList @out = null)
        {
            return new Operator("diag")
                .SetInput(data)
                .SetParam("k", k)
                .SetParam("axis1", axis1)
                .SetParam("axis2", axis2)
                .Invoke(@out);
        }

        public static NDArrayList Dot(NDArray lhs, NDArray rhs, bool transposea = false, bool transposeb = false, string forwardStype = "None", NDArrayList @out = null)
        {
            return new Operator("dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transpose_a", transposea)
                .SetParam("transpose_b", transposeb)
                .SetParam("forward_stype", forwardStype)
                .Invoke(@out);
        }

        public static NDArrayList BatchDot(NDArray lhs, NDArray rhs, bool transposea = false, bool transposeb = false, string forwardStype = "None", NDArrayList @out = null)
        {
            return new Operator("batch_dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transpose_a", transposea)
                .SetParam("transpose_b", transposeb)
                .SetParam("forward_stype", forwardStype)
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

        public static NDArrayList HardSigmoid(NDArray data, float? alpha = null, float? beta = null, NDArrayList @out = null)
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

        public static NDArrayList ShapeArray(NDArray data, int? lhsBegin = null, int? lhsEnd = null, int? rhsBegin = null, int? rhsEnd = null, NDArrayList @out = null)
        {
            return new Operator("shape_array")
                .SetInput(data)
                .SetParam("lhs_begin", lhsBegin)
                .SetParam("lhs_end", lhsEnd)
                .SetParam("rhs_begin", rhsBegin)
                .SetParam("rhs_end", rhsEnd)
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

        public static NDArrayList Embedding(NDArray data, NDArray weight, int inputDim, int outputDim, string dtype = "float32", bool sparseGrad = false, NDArrayList @out = null)
        {
            return new Operator("Embedding")
                .SetInput(data)
                .SetInput(weight)
                .SetParam("input_dim", inputDim)
                .SetParam("output_dim", outputDim)
                .SetParam("dtype", dtype)
                .SetParam("sparse_grad", sparseGrad)
                .Invoke(@out);
        }

        public static NDArrayList Take(NDArray a, NDArray indices, int? axis = null, string mode = "clip", NDArrayList @out = null)
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

        public static NDArrayList OneHot(NDArray indices, int depth, double? onValue = null, double? offValue = null, string dtype = "float32", NDArrayList @out = null)
        {
            return new Operator("one_hot")
                .SetInput(indices)
                .SetParam("depth", depth)
                .SetParam("on_value", onValue)
                .SetParam("off_value", offValue)
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

        public static NDArrayList Reshape(NDArray data, Shape shape = null, bool reverse = false, Shape targetShape = null, bool keepHighest = false, NDArrayList @out = null)
        {
            shape = new Shape();
            targetShape = new Shape();
            return new Operator("Reshape")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("reverse", reverse)
                .SetParam("target_shape", targetShape)
                .SetParam("keep_highest", keepHighest)
                .Invoke(@out);
        }

        public static NDArrayList Transpose(NDArray data, Shape axes = null, NDArrayList @out = null)
        {
            axes = new Shape();
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

        public static NDArrayList Slice(NDArray data, Shape begin, Shape end, Shape step = null, NDArrayList @out = null)
        {
            step = new Shape();
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

        public static NDArrayList SliceLike(NDArray data, NDArray shapeLike, Shape axes = null, NDArrayList @out = null)
        {
            axes = new Shape();
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
                .SetParam("a_min", aMin)
                .SetParam("a_max", aMax)
                .Invoke(@out);
        }

        public static NDArrayList Repeat(NDArray data, int repeats, int? axis = null, NDArrayList @out = null)
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

        public static NDArrayList Stack(NDArrayList data, int? axis = null, int? numArgs = null, NDArrayList @out = null)
        {
            return new Operator("stack")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("num_args", numArgs)
                .Invoke(@out);
        }

        public static NDArrayList Squeeze(NDArrayList data, Shape axis = null, NDArrayList @out = null)
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
                .SetParam("block_size", blockSize)
                .Invoke(@out);
        }

        public static NDArrayList SpaceToDepth(NDArray data, int blockSize, NDArrayList @out = null)
        {
            return new Operator("space_to_depth")
                .SetInput(data)
                .SetParam("block_size", blockSize)
                .Invoke(@out);
        }

        public static NDArrayList Topk(NDArray data, int? axis = null, int? k = null, string retTyp = "indices", bool isAscend = false, string dtype = "float32", NDArrayList @out = null)
        {
            return new Operator("topk")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("k", k)
                .SetParam("ret_typ", retTyp)
                .SetParam("is_ascend", isAscend)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList Sort(NDArray data, int? axis = null, bool isAscend = true, NDArrayList @out = null)
        {
            return new Operator("sort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("is_ascend", isAscend)
                .Invoke(@out);
        }

        public static NDArrayList Argsort(NDArray data, int? axis = null, bool isAscend = true, string dtype = "float32", NDArrayList @out = null)
        {
            return new Operator("argsort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("is_ascend", isAscend)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList BilinearSampler(NDArray data, NDArray grid, bool? cudnnOff = null, NDArrayList @out = null)
        {
            return new Operator("BilinearSampler")
                .SetInput(data)
                .SetInput(grid)
                .SetParam("cudnn_off", cudnnOff)
                .Invoke(@out);
        }

        public static NDArrayList ConvolutionV1(NDArray data, NDArray weight, NDArray bias, Shape kernel, Shape stride = null, Shape dilate = null, Shape pad = null, int? numFilter = null, int? numGroup = null, long? workspace = null, bool noBias = false, string cudnnTune = "None", bool cudnnOff = false, string layout = "None", NDArrayList @out = null)
        {
            stride = new Shape();
            dilate = new Shape();
            pad = new Shape();
            return new Operator("Convolution_v1")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("kernel", kernel)
                .SetParam("stride", stride)
                .SetParam("dilate", dilate)
                .SetParam("pad", pad)
                .SetParam("num_filter", numFilter)
                .SetParam("num_group", numGroup)
                .SetParam("workspace", workspace)
                .SetParam("no_bias", noBias)
                .SetParam("cudnn_tune", cudnnTune)
                .SetParam("cudnn_off", cudnnOff)
                .SetParam("layout", layout)
                .Invoke(@out);
        }

        public static NDArrayList Correlation(NDArray data1, NDArray data2, int? kernelSize = null, int? maxDisplacement = null, int? stride1 = null, int? stride2 = null, int? padSize = null, bool isMultiply = true, NDArrayList @out = null)
        {
            return new Operator("Correlation")
                .SetInput(data1)
                .SetInput(data2)
                .SetParam("kernel_size", kernelSize)
                .SetParam("max_displacement", maxDisplacement)
                .SetParam("stride1", stride1)
                .SetParam("stride2", stride2)
                .SetParam("pad_size", padSize)
                .SetParam("is_multiply", isMultiply)
                .Invoke(@out);
        }

        public static NDArrayList Crop(SymbolList data, int numArgs, Shape offset = null, Shape hw = null, bool centerCrop = false, NDArrayList @out = null)
        {
            offset = new [] {0,0};
            hw = new [] {0,0};
            return new Operator("Crop")
                .SetInput(data)
                .SetParam("num_args", numArgs)
                .SetParam("offset", offset)
                .SetParam("h_w", hw)
                .SetParam("center_crop", centerCrop)
                .Invoke(@out);
        }

        public static NDArrayList GridGenerator(NDArray data, string transformType, Shape targetShape = null, NDArrayList @out = null)
        {
            targetShape = new [] {0,0};
            return new Operator("GridGenerator")
                .SetInput(data)
                .SetParam("transform_type", transformType)
                .SetParam("target_shape", targetShape)
                .Invoke(@out);
        }

        public static NDArrayList InstanceNorm(NDArray data, NDArray gamma, NDArray beta, float? eps = null, NDArrayList @out = null)
        {
            return new Operator("InstanceNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("eps", eps)
                .Invoke(@out);
        }

        public static NDArrayList L2Normalization(NDArray data, float? eps = null, string mode = "instance", NDArrayList @out = null)
        {
            return new Operator("L2Normalization")
                .SetInput(data)
                .SetParam("eps", eps)
                .SetParam("mode", mode)
                .Invoke(@out);
        }

        public static NDArrayList MakeLoss(NDArray data, float? gradScale = null, float? validThresh = null, string normalization = "null", NDArrayList @out = null)
        {
            return new Operator("MakeLoss")
                .SetInput(data)
                .SetParam("grad_scale", gradScale)
                .SetParam("valid_thresh", validThresh)
                .SetParam("normalization", normalization)
                .Invoke(@out);
        }

        public static NDArrayList PoolingV1(NDArray data, Shape kernel = null, string poolType = "max", bool globalPool = false, string poolingConvention = "valid", Shape stride = null, Shape pad = null, NDArrayList @out = null)
        {
            kernel = new Shape();
            stride = new Shape();
            pad = new Shape();
            return new Operator("Pooling_v1")
                .SetInput(data)
                .SetParam("kernel", kernel)
                .SetParam("pool_type", poolType)
                .SetParam("global_pool", globalPool)
                .SetParam("pooling_convention", poolingConvention)
                .SetParam("stride", stride)
                .SetParam("pad", pad)
                .Invoke(@out);
        }

        public static NDArrayList ROIPooling(NDArray data, NDArray rois, Shape pooledSize, float spatialScale, NDArrayList @out = null)
        {
            return new Operator("ROIPooling")
                .SetInput(data)
                .SetInput(rois)
                .SetParam("pooled_size", pooledSize)
                .SetParam("spatial_scale", spatialScale)
                .Invoke(@out);
        }

        public static NDArrayList SequenceLast(NDArray data, NDArray sequenceLength, bool useSequenceLength = false, int? axis = null, NDArrayList @out = null)
        {
            return new Operator("SequenceLast")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("use_sequence_length", useSequenceLength)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList SequenceMask(NDArray data, NDArray sequenceLength, bool useSequenceLength = false, float? value = null, int? axis = null, NDArrayList @out = null)
        {
            return new Operator("SequenceMask")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("use_sequence_length", useSequenceLength)
                .SetParam("value", value)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList SequenceReverse(NDArray data, NDArray sequenceLength, bool useSequenceLength = false, int? axis = null, NDArrayList @out = null)
        {
            return new Operator("SequenceReverse")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("use_sequence_length", useSequenceLength)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList SpatialTransformer(NDArray data, NDArray loc, Shape targetShape = null, string transformType = "null", string samplerType = "null", bool? cudnnOff = null, NDArrayList @out = null)
        {
            targetShape = new [] {0,0};
            return new Operator("SpatialTransformer")
                .SetInput(data)
                .SetInput(loc)
                .SetParam("target_shape", targetShape)
                .SetParam("transform_type", transformType)
                .SetParam("sampler_type", samplerType)
                .SetParam("cudnn_off", cudnnOff)
                .Invoke(@out);
        }

        public static NDArrayList SVMOutput(NDArray data, NDArray label, float? margin = null, float? regularizationCoefficient = null, bool useLinear = false, NDArrayList @out = null)
        {
            return new Operator("SVMOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("margin", margin)
                .SetParam("regularization_coefficient", regularizationCoefficient)
                .SetParam("use_linear", useLinear)
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
