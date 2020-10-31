using System;
using Horker.MXNet;
using Horker.MXNet.Interop;

namespace Horker.MXNet
{
    public partial class Symbol : SymbolBase
    {
        public static class Op
        {
        public static SymbolList BatchNormV1(Symbol data, Symbol gamma, Symbol beta, float? eps = null, float? momentum = null, bool fixGamma = true, bool useGlobalStats = false, bool outputMeanVar = false, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList AllFinite(NDArray data, bool initOutput = true, string symbolName = "null")
        {
            return new Operator("all_finite")
                .SetInput(data)
                .SetParam("init_output", initOutput)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MultiAllFinite(SymbolList data, int? numArrays = null, bool initOutput = true, string symbolName = "null")
        {
            return new Operator("multi_all_finite")
                .SetInput(data)
                .SetParam("num_arrays", numArrays)
                .SetParam("init_output", initOutput)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList KhatriRao(SymbolList args, string symbolName = "null")
        {
            return new Operator("khatri_rao")
                .SetInput(args)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Custom(SymbolList data, string opType, string symbolName = "null")
        {
            return new Operator("Custom")
                .SetInput(data)
                .SetParam("op_type", opType)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList IdentityAttachKLSparseReg(Symbol data, float? sparsenessTarget = null, float? penalty = null, float? momentum = null, string symbolName = "null")
        {
            return new Operator("IdentityAttachKLSparseReg")
                .SetInput(data)
                .SetParam("sparseness_target", sparsenessTarget)
                .SetParam("penalty", penalty)
                .SetParam("momentum", momentum)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList LeakyReLU(Symbol data, Symbol gamma, string actType = "leaky", float? slope = null, float? lowerBound = null, float? upperBound = null, string symbolName = "null")
        {
            return new Operator("LeakyReLU")
                .SetInput(data)
                .SetInput(gamma)
                .SetParam("act_type", actType)
                .SetParam("slope", slope)
                .SetParam("lower_bound", lowerBound)
                .SetParam("upper_bound", upperBound)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SoftmaxCrossEntropy(Symbol data, Symbol label, string symbolName = "null")
        {
            return new Operator("softmax_cross_entropy")
                .SetInput(data)
                .SetInput(label)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Activation(Symbol data, string actType, string symbolName = "null")
        {
            return new Operator("Activation")
                .SetInput(data)
                .SetParam("act_type", actType)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BatchNorm(Symbol data, Symbol gamma, Symbol beta, Symbol movingMean, Symbol movingVar, double? eps = null, float? momentum = null, bool fixGamma = true, bool useGlobalStats = false, bool outputMeanVar = false, int? axis = null, bool cudnnOff = false, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Concat(SymbolList data, int numArgs, int? dim = null, string symbolName = "null")
        {
            return new Operator("Concat")
                .SetInput(data)
                .SetParam("num_args", numArgs)
                .SetParam("dim", dim)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Convolution(Symbol data, Symbol weight, Symbol bias, Shape kernel, Shape stride = null, Shape dilate = null, Shape pad = null, int? numFilter = null, int? numGroup = null, long? workspace = null, bool noBias = false, string cudnnTune = "None", bool cudnnOff = false, string layout = "None", string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList CTCLoss(Symbol data, Symbol label, Symbol dataLengths, Symbol labelLengths, bool useDataLengths = false, bool useLabelLengths = false, string blankLabel = "first", string symbolName = "null")
        {
            return new Operator("CTCLoss")
                .SetInput(data)
                .SetInput(label)
                .SetInput(dataLengths)
                .SetInput(labelLengths)
                .SetParam("use_data_lengths", useDataLengths)
                .SetParam("use_label_lengths", useLabelLengths)
                .SetParam("blank_label", blankLabel)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Deconvolution(Symbol data, Symbol weight, Symbol bias, Shape kernel, Shape stride = null, Shape dilate = null, Shape pad = null, Shape adj = null, Shape targetShape = null, int? numFilter = null, int? numGroup = null, long? workspace = null, bool noBias = true, string cudnnTune = "None", bool cudnnOff = false, string layout = "None", string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Dropout(Symbol data, float? p = null, string mode = "training", Shape axes = null, bool cudnnOff = false, string symbolName = "null")
        {
            axes = new Shape();
            return new Operator("Dropout")
                .SetInput(data)
                .SetParam("p", p)
                .SetParam("mode", mode)
                .SetParam("axes", axes)
                .SetParam("cudnn_off", cudnnOff)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList FullyConnected(Symbol data, Symbol weight, Symbol bias, int numHidden, bool noBias = false, bool flatten = true, string symbolName = "null")
        {
            return new Operator("FullyConnected")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("num_hidden", numHidden)
                .SetParam("no_bias", noBias)
                .SetParam("flatten", flatten)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList LayerNorm(Symbol data, Symbol gamma, Symbol beta, int? axis = null, float? eps = null, bool outputMeanVar = false, string symbolName = "null")
        {
            return new Operator("LayerNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("axis", axis)
                .SetParam("eps", eps)
                .SetParam("output_mean_var", outputMeanVar)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList LRN(Symbol data, float? alpha = null, float? beta = null, float? knorm = null, int? nsize = null, string symbolName = "null")
        {
            return new Operator("LRN")
                .SetInput(data)
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetParam("knorm", knorm)
                .SetParam("nsize", nsize)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Moments(Symbol data, Shape axes = null, bool keepdims = false, string symbolName = "null")
        {
            return new Operator("moments")
                .SetInput(data)
                .SetParam("axes", axes)
                .SetParam("keepdims", keepdims)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Pooling(Symbol data, Shape kernel = null, string poolType = "max", bool globalPool = false, bool cudnnOff = false, string poolingConvention = "valid", Shape stride = null, Shape pad = null, int? pValue = null, bool? countIncludePad = null, string layout = "None", string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Softmax(Symbol data, int? axis = null, double? temperature = null, string dtype = "None", string symbolName = "null")
        {
            return new Operator("softmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Softmin(Symbol data, int? axis = null, double? temperature = null, string dtype = "None", string symbolName = "null")
        {
            return new Operator("softmin")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList LogSoftmax(Symbol data, int? axis = null, double? temperature = null, string dtype = "None", string symbolName = "null")
        {
            return new Operator("log_softmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("temperature", temperature)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SoftmaxActivation(Symbol data, string mode = "instance", string symbolName = "null")
        {
            return new Operator("SoftmaxActivation")
                .SetInput(data)
                .SetParam("mode", mode)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList UpSampling(SymbolList data, int scale, int? numFilter = null, string sampleType = "null", string multiInputMode = "concat", int? numArgs = null, long? workspace = null, string symbolName = "null")
        {
            return new Operator("UpSampling")
                .SetInput(data)
                .SetParam("scale", scale)
                .SetParam("num_filter", numFilter)
                .SetParam("sample_type", sampleType)
                .SetParam("multi_input_mode", multiInputMode)
                .SetParam("num_args", numArgs)
                .SetParam("workspace", workspace)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SignsgdUpdate(Symbol weight, Symbol grad, float lr, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, string symbolName = "null")
        {
            return new Operator("signsgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SignumUpdate(Symbol weight, Symbol grad, Symbol mom, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, float? wdLh = null, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MultiSgdUpdate(SymbolList data, object lrs, object wds, float? rescaleGrad = null, float? clipGradient = null, int? numWeights = null, string symbolName = "null")
        {
            return new Operator("multi_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("num_weights", numWeights)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MultiSgdMomUpdate(SymbolList data, object lrs, object wds, float? momentum = null, float? rescaleGrad = null, float? clipGradient = null, int? numWeights = null, string symbolName = "null")
        {
            return new Operator("multi_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("num_weights", numWeights)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MultiMpSgdUpdate(SymbolList data, object lrs, object wds, float? rescaleGrad = null, float? clipGradient = null, int? numWeights = null, string symbolName = "null")
        {
            return new Operator("multi_mp_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("num_weights", numWeights)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MultiMpSgdMomUpdate(SymbolList data, object lrs, object wds, float? momentum = null, float? rescaleGrad = null, float? clipGradient = null, int? numWeights = null, string symbolName = "null")
        {
            return new Operator("multi_mp_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("num_weights", numWeights)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SgdUpdate(Symbol weight, Symbol grad, float lr, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, string symbolName = "null")
        {
            return new Operator("sgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescaleGrad)
                .SetParam("clip_gradient", clipGradient)
                .SetParam("lazy_update", lazyUpdate)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SgdMomUpdate(Symbol weight, Symbol grad, Symbol mom, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MpSgdUpdate(Symbol weight, Symbol grad, Symbol weight32, float lr, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MpSgdMomUpdate(Symbol weight, Symbol grad, Symbol mom, Symbol weight32, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList FtmlUpdate(Symbol weight, Symbol grad, Symbol d, Symbol v, Symbol z, float lr, float? beta1 = null, float? beta2 = null, double? epsilon = null, int? t = null, float? wd = null, float? rescaleGrad = null, float? clipGrad = null, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList AdamUpdate(Symbol weight, Symbol grad, Symbol mean, Symbol var, float lr, float? beta1 = null, float? beta2 = null, float? epsilon = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, bool lazyUpdate = true, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList NagMomUpdate(Symbol weight, Symbol grad, Symbol mom, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MpNagMomUpdate(Symbol weight, Symbol grad, Symbol mom, Symbol weight32, float lr, float? momentum = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList RmspropUpdate(Symbol weight, Symbol grad, Symbol n, float lr, float? gamma1 = null, float? epsilon = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, float? clipWeights = null, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList RmspropalexUpdate(Symbol weight, Symbol grad, Symbol n, Symbol g, Symbol delta, float lr, float? gamma1 = null, float? gamma2 = null, float? epsilon = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, float? clipWeights = null, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList FtrlUpdate(Symbol weight, Symbol grad, Symbol z, Symbol n, float lr, float? lamda1 = null, float? beta = null, float? wd = null, float? rescaleGrad = null, float? clipGradient = null, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Pad(Symbol data, string mode, Shape padWidth, double? constantValue = null, string symbolName = "null")
        {
            return new Operator("Pad")
                .SetInput(data)
                .SetParam("mode", mode)
                .SetParam("pad_width", padWidth)
                .SetParam("constant_value", constantValue)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Flatten(Symbol data, string symbolName = "null")
        {
            return new Operator("Flatten")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList LinearRegressionOutput(Symbol data, Symbol label, float? gradScale = null, string symbolName = "null")
        {
            return new Operator("LinearRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", gradScale)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MAERegressionOutput(Symbol data, Symbol label, float? gradScale = null, string symbolName = "null")
        {
            return new Operator("MAERegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", gradScale)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList LogisticRegressionOutput(Symbol data, Symbol label, float? gradScale = null, string symbolName = "null")
        {
            return new Operator("LogisticRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", gradScale)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList RNN(Symbol data, Symbol parameters, Symbol state, Symbol stateCell, Symbol sequenceLength, int stateSize, int numLayers, bool bidirectional = false, string mode = "null", float? p = null, bool stateOutputs = false, int? projectionSize = null, double? lstmStateClipMin = null, double? lstmStateClipMax = null, bool lstmStateClipNan = false, bool useSequenceLength = false, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SliceChannel(Symbol data, int numOutputs, int? axis = null, bool squeezeAxis = false, string symbolName = "null")
        {
            return new Operator("SliceChannel")
                .SetInput(data)
                .SetParam("num_outputs", numOutputs)
                .SetParam("axis", axis)
                .SetParam("squeeze_axis", squeezeAxis)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SoftmaxOutput(Symbol data, Symbol label, float? gradScale = null, float? ignoreLabel = null, bool multiOutput = false, bool useIgnore = false, bool preserveShape = false, string normalization = "null", bool outGrad = false, float? smoothAlpha = null, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SwapAxis(Symbol data, int? dim1 = null, int? dim2 = null, string symbolName = "null")
        {
            return new Operator("SwapAxis")
                .SetInput(data)
                .SetParam("dim1", dim1)
                .SetParam("dim2", dim2)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList AmpCast(Symbol data, string dtype, string symbolName = "null")
        {
            return new Operator("amp_cast")
                .SetInput(data)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList AmpMulticast(SymbolList data, int numOutputs, string symbolName = "null")
        {
            return new Operator("amp_multicast")
                .SetInput(data)
                .SetParam("num_outputs", numOutputs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Argmax(Symbol data, int? axis = null, bool keepdims = false, string symbolName = "null")
        {
            return new Operator("argmax")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Argmin(Symbol data, int? axis = null, bool keepdims = false, string symbolName = "null")
        {
            return new Operator("argmin")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ArgmaxChannel(Symbol data, string symbolName = "null")
        {
            return new Operator("argmax_channel")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Pick(Symbol data, Symbol index, int? axis = null, bool keepdims = false, string mode = "clip", string symbolName = "null")
        {
            return new Operator("pick")
                .SetInput(data)
                .SetInput(index)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("mode", mode)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Sum(Symbol data, Shape axis = null, bool keepdims = false, bool exclude = false, string symbolName = "null")
        {
            return new Operator("sum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Mean(Symbol data, Shape axis = null, bool keepdims = false, bool exclude = false, string symbolName = "null")
        {
            return new Operator("mean")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Prod(Symbol data, Shape axis = null, bool keepdims = false, bool exclude = false, string symbolName = "null")
        {
            return new Operator("prod")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Nansum(Symbol data, Shape axis = null, bool keepdims = false, bool exclude = false, string symbolName = "null")
        {
            return new Operator("nansum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Nanprod(Symbol data, Shape axis = null, bool keepdims = false, bool exclude = false, string symbolName = "null")
        {
            return new Operator("nanprod")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Max(Symbol data, Shape axis = null, bool keepdims = false, bool exclude = false, string symbolName = "null")
        {
            return new Operator("max")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Min(Symbol data, Shape axis = null, bool keepdims = false, bool exclude = false, string symbolName = "null")
        {
            return new Operator("min")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastAxis(Symbol data, Shape axis = null, Shape size = null, string symbolName = "null")
        {
            axis = new Shape();
            size = new Shape();
            return new Operator("broadcast_axis")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("size", size)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastTo(Symbol data, Shape shape = null, string symbolName = "null")
        {
            shape = new Shape();
            return new Operator("broadcast_to")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastLike(Symbol lhs, Symbol rhs, Shape lhsAxes = null, Shape rhsAxes = null, string symbolName = "null")
        {
            return new Operator("broadcast_like")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("lhs_axes", lhsAxes)
                .SetParam("rhs_axes", rhsAxes)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Norm(Symbol data, int? ord = null, Shape axis = null, string outDtype = "None", bool keepdims = false, string symbolName = "null")
        {
            return new Operator("norm")
                .SetInput(data)
                .SetParam("ord", ord)
                .SetParam("axis", axis)
                .SetParam("out_dtype", outDtype)
                .SetParam("keepdims", keepdims)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList CastStorage(Symbol data, string stype, string symbolName = "null")
        {
            return new Operator("cast_storage")
                .SetInput(data)
                .SetParam("stype", stype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Where(Symbol condition, Symbol x, Symbol y, string symbolName = "null")
        {
            return new Operator("where")
                .SetInput(condition)
                .SetInput(x)
                .SetInput(y)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Diag(Symbol data, int? k = null, int? axis1 = null, int? axis2 = null, string symbolName = "null")
        {
            return new Operator("diag")
                .SetInput(data)
                .SetParam("k", k)
                .SetParam("axis1", axis1)
                .SetParam("axis2", axis2)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Dot(Symbol lhs, Symbol rhs, bool transposea = false, bool transposeb = false, string forwardStype = "None", string symbolName = "null")
        {
            return new Operator("dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transpose_a", transposea)
                .SetParam("transpose_b", transposeb)
                .SetParam("forward_stype", forwardStype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BatchDot(Symbol lhs, Symbol rhs, bool transposea = false, bool transposeb = false, string forwardStype = "None", string symbolName = "null")
        {
            return new Operator("batch_dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transpose_a", transposea)
                .SetParam("transpose_b", transposeb)
                .SetParam("forward_stype", forwardStype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastAdd(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastSub(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_sub")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastMul(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_mul")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastDiv(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_div")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastMod(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_mod")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastPower(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_power")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastMaximum(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_maximum")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastMinimum(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_minimum")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastHypot(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_hypot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastEqual(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastNotEqual(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_not_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastGreater(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_greater")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastGreaterEqual(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_greater_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastLesser(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_lesser")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastLesserEqual(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_lesser_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastLogicalAnd(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_logical_and")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastLogicalOr(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_logical_or")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BroadcastLogicalXor(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("broadcast_logical_xor")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ElemwiseAdd(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("elemwise_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ElemwiseSub(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("elemwise_sub")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ElemwiseMul(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("elemwise_mul")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ElemwiseDiv(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("elemwise_div")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SmoothL1(Symbol data, float scalar, string symbolName = "null")
        {
            return new Operator("smooth_l1")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Addn(SymbolList args, string symbolName = "null")
        {
            return new Operator("add_n")
                .SetInput(args)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Relu(Symbol data, string symbolName = "null")
        {
            return new Operator("relu")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Sigmoid(Symbol data, string symbolName = "null")
        {
            return new Operator("sigmoid")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList HardSigmoid(Symbol data, float? alpha = null, float? beta = null, string symbolName = "null")
        {
            return new Operator("hard_sigmoid")
                .SetInput(data)
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Softsign(Symbol data, string symbolName = "null")
        {
            return new Operator("softsign")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BlockGrad(Symbol data, string symbolName = "null")
        {
            return new Operator("BlockGrad")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MakeLoss(Symbol data, string symbolName = "null")
        {
            return new Operator("make_loss")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ReshapeLike(Symbol lhs, Symbol rhs, string symbolName = "null")
        {
            return new Operator("reshape_like")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ShapeArray(Symbol data, int? lhsBegin = null, int? lhsEnd = null, int? rhsBegin = null, int? rhsEnd = null, string symbolName = "null")
        {
            return new Operator("shape_array")
                .SetInput(data)
                .SetParam("lhs_begin", lhsBegin)
                .SetParam("lhs_end", lhsEnd)
                .SetParam("rhs_begin", rhsBegin)
                .SetParam("rhs_end", rhsEnd)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SizeArray(Symbol data, string symbolName = "null")
        {
            return new Operator("size_array")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Cast(Symbol data, string dtype, string symbolName = "null")
        {
            return new Operator("Cast")
                .SetInput(data)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Negative(Symbol data, string symbolName = "null")
        {
            return new Operator("negative")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Reciprocal(Symbol data, string symbolName = "null")
        {
            return new Operator("reciprocal")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Abs(Symbol data, string symbolName = "null")
        {
            return new Operator("abs")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Sign(Symbol data, string symbolName = "null")
        {
            return new Operator("sign")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Round(Symbol data, string symbolName = "null")
        {
            return new Operator("round")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Rint(Symbol data, string symbolName = "null")
        {
            return new Operator("rint")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Ceil(Symbol data, string symbolName = "null")
        {
            return new Operator("ceil")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Floor(Symbol data, string symbolName = "null")
        {
            return new Operator("floor")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Trunc(Symbol data, string symbolName = "null")
        {
            return new Operator("trunc")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Fix(Symbol data, string symbolName = "null")
        {
            return new Operator("fix")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Square(Symbol data, string symbolName = "null")
        {
            return new Operator("square")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Sqrt(Symbol data, string symbolName = "null")
        {
            return new Operator("sqrt")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Rsqrt(Symbol data, string symbolName = "null")
        {
            return new Operator("rsqrt")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Cbrt(Symbol data, string symbolName = "null")
        {
            return new Operator("cbrt")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Erf(Symbol data, string symbolName = "null")
        {
            return new Operator("erf")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Erfinv(Symbol data, string symbolName = "null")
        {
            return new Operator("erfinv")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Rcbrt(Symbol data, string symbolName = "null")
        {
            return new Operator("rcbrt")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Exp(Symbol data, string symbolName = "null")
        {
            return new Operator("exp")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Log(Symbol data, string symbolName = "null")
        {
            return new Operator("log")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Log10(Symbol data, string symbolName = "null")
        {
            return new Operator("log10")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Log2(Symbol data, string symbolName = "null")
        {
            return new Operator("log2")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Log1p(Symbol data, string symbolName = "null")
        {
            return new Operator("log1p")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Expm1(Symbol data, string symbolName = "null")
        {
            return new Operator("expm1")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Gamma(Symbol data, string symbolName = "null")
        {
            return new Operator("gamma")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Gammaln(Symbol data, string symbolName = "null")
        {
            return new Operator("gammaln")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList LogicalNot(Symbol data, string symbolName = "null")
        {
            return new Operator("logical_not")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Sin(Symbol data, string symbolName = "null")
        {
            return new Operator("sin")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Cos(Symbol data, string symbolName = "null")
        {
            return new Operator("cos")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Tan(Symbol data, string symbolName = "null")
        {
            return new Operator("tan")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Arcsin(Symbol data, string symbolName = "null")
        {
            return new Operator("arcsin")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Arccos(Symbol data, string symbolName = "null")
        {
            return new Operator("arccos")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Arctan(Symbol data, string symbolName = "null")
        {
            return new Operator("arctan")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Degrees(Symbol data, string symbolName = "null")
        {
            return new Operator("degrees")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Radians(Symbol data, string symbolName = "null")
        {
            return new Operator("radians")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Sinh(Symbol data, string symbolName = "null")
        {
            return new Operator("sinh")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Cosh(Symbol data, string symbolName = "null")
        {
            return new Operator("cosh")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Tanh(Symbol data, string symbolName = "null")
        {
            return new Operator("tanh")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Arcsinh(Symbol data, string symbolName = "null")
        {
            return new Operator("arcsinh")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Arccosh(Symbol data, string symbolName = "null")
        {
            return new Operator("arccosh")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Arctanh(Symbol data, string symbolName = "null")
        {
            return new Operator("arctanh")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Embedding(Symbol data, Symbol weight, int inputDim, int outputDim, string dtype = "float32", bool sparseGrad = false, string symbolName = "null")
        {
            return new Operator("Embedding")
                .SetInput(data)
                .SetInput(weight)
                .SetParam("input_dim", inputDim)
                .SetParam("output_dim", outputDim)
                .SetParam("dtype", dtype)
                .SetParam("sparse_grad", sparseGrad)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Take(Symbol a, Symbol indices, int? axis = null, string mode = "clip", string symbolName = "null")
        {
            return new Operator("take")
                .SetInput(a)
                .SetInput(indices)
                .SetParam("axis", axis)
                .SetParam("mode", mode)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BatchTake(Symbol a, Symbol indices, string symbolName = "null")
        {
            return new Operator("batch_take")
                .SetInput(a)
                .SetInput(indices)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList OneHot(Symbol indices, int depth, double? onValue = null, double? offValue = null, string dtype = "float32", string symbolName = "null")
        {
            return new Operator("one_hot")
                .SetInput(indices)
                .SetParam("depth", depth)
                .SetParam("on_value", onValue)
                .SetParam("off_value", offValue)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList GatherNd(Symbol data, Symbol indices, string symbolName = "null")
        {
            return new Operator("gather_nd")
                .SetInput(data)
                .SetInput(indices)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ScatterNd(Symbol data, Symbol indices, Shape shape, string symbolName = "null")
        {
            return new Operator("scatter_nd")
                .SetInput(data)
                .SetInput(indices)
                .SetParam("shape", shape)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ZerosLike(Symbol data, string symbolName = "null")
        {
            return new Operator("zeros_like")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList OnesLike(Symbol data, string symbolName = "null")
        {
            return new Operator("ones_like")
                .SetInput(data)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Reshape(Symbol data, Shape shape = null, bool reverse = false, Shape targetShape = null, bool keepHighest = false, string symbolName = "null")
        {
            shape = new Shape();
            targetShape = new Shape();
            return new Operator("Reshape")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("reverse", reverse)
                .SetParam("target_shape", targetShape)
                .SetParam("keep_highest", keepHighest)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Transpose(Symbol data, Shape axes = null, string symbolName = "null")
        {
            axes = new Shape();
            return new Operator("transpose")
                .SetInput(data)
                .SetParam("axes", axes)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ExpandDims(Symbol data, int axis, string symbolName = "null")
        {
            return new Operator("expand_dims")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Slice(Symbol data, Shape begin, Shape end, Shape step = null, string symbolName = "null")
        {
            step = new Shape();
            return new Operator("slice")
                .SetInput(data)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetParam("step", step)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SliceAxis(Symbol data, int axis, int begin, int end, string symbolName = "null")
        {
            return new Operator("slice_axis")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SliceLike(Symbol data, Symbol shapeLike, Shape axes = null, string symbolName = "null")
        {
            axes = new Shape();
            return new Operator("slice_like")
                .SetInput(data)
                .SetInput(shapeLike)
                .SetParam("axes", axes)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Clip(Symbol data, float aMin, float aMax, string symbolName = "null")
        {
            return new Operator("clip")
                .SetInput(data)
                .SetParam("a_min", aMin)
                .SetParam("a_max", aMax)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Repeat(Symbol data, int repeats, int? axis = null, string symbolName = "null")
        {
            return new Operator("repeat")
                .SetInput(data)
                .SetParam("repeats", repeats)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Tile(Symbol data, Shape reps, string symbolName = "null")
        {
            return new Operator("tile")
                .SetInput(data)
                .SetParam("reps", reps)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Reverse(Symbol data, Shape axis, string symbolName = "null")
        {
            return new Operator("reverse")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Stack(SymbolList data, int? axis = null, int? numArgs = null, string symbolName = "null")
        {
            return new Operator("stack")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("num_args", numArgs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Squeeze(SymbolList data, Shape axis = null, string symbolName = "null")
        {
            return new Operator("squeeze")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList DepthToSpace(Symbol data, int blockSize, string symbolName = "null")
        {
            return new Operator("depth_to_space")
                .SetInput(data)
                .SetParam("block_size", blockSize)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SpaceToDepth(Symbol data, int blockSize, string symbolName = "null")
        {
            return new Operator("space_to_depth")
                .SetInput(data)
                .SetParam("block_size", blockSize)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Topk(Symbol data, int? axis = null, int? k = null, string retTyp = "indices", bool isAscend = false, string dtype = "float32", string symbolName = "null")
        {
            return new Operator("topk")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("k", k)
                .SetParam("ret_typ", retTyp)
                .SetParam("is_ascend", isAscend)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Sort(Symbol data, int? axis = null, bool isAscend = true, string symbolName = "null")
        {
            return new Operator("sort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("is_ascend", isAscend)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Argsort(Symbol data, int? axis = null, bool isAscend = true, string dtype = "float32", string symbolName = "null")
        {
            return new Operator("argsort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("is_ascend", isAscend)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList BilinearSampler(Symbol data, Symbol grid, bool? cudnnOff = null, string symbolName = "null")
        {
            return new Operator("BilinearSampler")
                .SetInput(data)
                .SetInput(grid)
                .SetParam("cudnn_off", cudnnOff)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ConvolutionV1(Symbol data, Symbol weight, Symbol bias, Shape kernel, Shape stride = null, Shape dilate = null, Shape pad = null, int? numFilter = null, int? numGroup = null, long? workspace = null, bool noBias = false, string cudnnTune = "None", bool cudnnOff = false, string layout = "None", string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Correlation(Symbol data1, Symbol data2, int? kernelSize = null, int? maxDisplacement = null, int? stride1 = null, int? stride2 = null, int? padSize = null, bool isMultiply = true, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList Crop(SymbolList data, int numArgs, Shape offset = null, Shape hw = null, bool centerCrop = false, string symbolName = "null")
        {
            offset = new [] {0,0};
            hw = new [] {0,0};
            return new Operator("Crop")
                .SetInput(data)
                .SetParam("num_args", numArgs)
                .SetParam("offset", offset)
                .SetParam("h_w", hw)
                .SetParam("center_crop", centerCrop)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList GridGenerator(Symbol data, string transformType, Shape targetShape = null, string symbolName = "null")
        {
            targetShape = new [] {0,0};
            return new Operator("GridGenerator")
                .SetInput(data)
                .SetParam("transform_type", transformType)
                .SetParam("target_shape", targetShape)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList InstanceNorm(Symbol data, Symbol gamma, Symbol beta, float? eps = null, string symbolName = "null")
        {
            return new Operator("InstanceNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("eps", eps)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList L2Normalization(Symbol data, float? eps = null, string mode = "instance", string symbolName = "null")
        {
            return new Operator("L2Normalization")
                .SetInput(data)
                .SetParam("eps", eps)
                .SetParam("mode", mode)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList MakeLoss(Symbol data, float? gradScale = null, float? validThresh = null, string normalization = "null", string symbolName = "null")
        {
            return new Operator("MakeLoss")
                .SetInput(data)
                .SetParam("grad_scale", gradScale)
                .SetParam("valid_thresh", validThresh)
                .SetParam("normalization", normalization)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList PoolingV1(Symbol data, Shape kernel = null, string poolType = "max", bool globalPool = false, string poolingConvention = "valid", Shape stride = null, Shape pad = null, string symbolName = "null")
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
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList ROIPooling(Symbol data, Symbol rois, Shape pooledSize, float spatialScale, string symbolName = "null")
        {
            return new Operator("ROIPooling")
                .SetInput(data)
                .SetInput(rois)
                .SetParam("pooled_size", pooledSize)
                .SetParam("spatial_scale", spatialScale)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SequenceLast(Symbol data, Symbol sequenceLength, bool useSequenceLength = false, int? axis = null, string symbolName = "null")
        {
            return new Operator("SequenceLast")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("use_sequence_length", useSequenceLength)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SequenceMask(Symbol data, Symbol sequenceLength, bool useSequenceLength = false, float? value = null, int? axis = null, string symbolName = "null")
        {
            return new Operator("SequenceMask")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("use_sequence_length", useSequenceLength)
                .SetParam("value", value)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SequenceReverse(Symbol data, Symbol sequenceLength, bool useSequenceLength = false, int? axis = null, string symbolName = "null")
        {
            return new Operator("SequenceReverse")
                .SetInput(data)
                .SetInput(sequenceLength)
                .SetParam("use_sequence_length", useSequenceLength)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SpatialTransformer(Symbol data, Symbol loc, Shape targetShape = null, string transformType = "null", string samplerType = "null", bool? cudnnOff = null, string symbolName = "null")
        {
            targetShape = new [] {0,0};
            return new Operator("SpatialTransformer")
                .SetInput(data)
                .SetInput(loc)
                .SetParam("target_shape", targetShape)
                .SetParam("transform_type", transformType)
                .SetParam("sampler_type", samplerType)
                .SetParam("cudnn_off", cudnnOff)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList SVMOutput(Symbol data, Symbol label, float? margin = null, float? regularizationCoefficient = null, bool useLinear = false, string symbolName = "null")
        {
            return new Operator("SVMOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("margin", margin)
                .SetParam("regularization_coefficient", regularizationCoefficient)
                .SetParam("use_linear", useLinear)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        public static SymbolList FillElement0index(NDArray lhs, NDArray mhs, NDArray rhs, string symbolName = "null")
        {
            return new Operator("fill_element_0index")
                .SetInput(lhs)
                .SetInput(mhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbolName)
                .CreateSymbol(symbolName);
        }

        }
    }
}
