using System;
using Horker.MXNet;
using Horker.MXNet.Interop;

namespace Horker.MXNet
{
    public partial class NDArray : NDArrayBase
    {
        public static class Op
        {
        public static NDArrayList BatchNormV1(NDArray data, NDArray gamma, NDArray beta, float eps, float momentum, bool fix_gamma, bool use_global_stats, bool output_mean_var, NDArrayList @out = null)
        {
            return new Operator("BatchNorm_v1")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("eps", eps)
                .SetParam("momentum", momentum)
                .SetParam("fix_gamma", fix_gamma)
                .SetParam("use_global_stats", use_global_stats)
                .SetParam("output_mean_var", output_mean_var)
                .Invoke(@out);
        }

        public static NDArrayList AllFinite(NDArray data, bool init_output, NDArrayList @out = null)
        {
            return new Operator("all_finite")
                .SetInput(data)
                .SetParam("init_output", init_output)
                .Invoke(@out);
        }

        public static NDArrayList MultiAllFinite(NDArrayList data, int num_arrays, bool init_output, NDArrayList @out = null)
        {
            return new Operator("multi_all_finite")
                .SetInput(data)
                .SetParam("num_arrays", num_arrays)
                .SetParam("init_output", init_output)
                .Invoke(@out);
        }

        public static NDArrayList KhatriRao(NDArrayList args, NDArrayList @out = null)
        {
            return new Operator("khatri_rao")
                .SetInput(args)
                .Invoke(@out);
        }

        public static NDArrayList Custom(NDArrayList data, string op_type, NDArrayList @out = null)
        {
            return new Operator("Custom")
                .SetInput(data)
                .SetParam("op_type", op_type)
                .Invoke(@out);
        }

        public static NDArrayList IdentityAttachKLSparseReg(NDArray data, float sparseness_target, float penalty, float momentum, NDArrayList @out = null)
        {
            return new Operator("IdentityAttachKLSparseReg")
                .SetInput(data)
                .SetParam("sparseness_target", sparseness_target)
                .SetParam("penalty", penalty)
                .SetParam("momentum", momentum)
                .Invoke(@out);
        }

        public static NDArrayList LeakyReLU(NDArray data, NDArray gamma, string act_type, float slope, float lower_bound, float upper_bound, NDArrayList @out = null)
        {
            return new Operator("LeakyReLU")
                .SetInput(data)
                .SetInput(gamma)
                .SetParam("act_type", act_type)
                .SetParam("slope", slope)
                .SetParam("lower_bound", lower_bound)
                .SetParam("upper_bound", upper_bound)
                .Invoke(@out);
        }

        public static NDArrayList SoftmaxCrossEntropy(NDArray data, NDArray label, NDArrayList @out = null)
        {
            return new Operator("softmax_cross_entropy")
                .SetInput(data)
                .SetInput(label)
                .Invoke(@out);
        }

        public static NDArrayList Activation(NDArray data, string act_type, NDArrayList @out = null)
        {
            return new Operator("Activation")
                .SetInput(data)
                .SetParam("act_type", act_type)
                .Invoke(@out);
        }

        public static NDArrayList BatchNorm(NDArray data, NDArray gamma, NDArray beta, NDArray moving_mean, NDArray moving_var, double eps, float momentum, bool fix_gamma, bool use_global_stats, bool output_mean_var, int axis, bool cudnn_off, NDArrayList @out = null)
        {
            return new Operator("BatchNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetInput(moving_mean)
                .SetInput(moving_var)
                .SetParam("eps", eps)
                .SetParam("momentum", momentum)
                .SetParam("fix_gamma", fix_gamma)
                .SetParam("use_global_stats", use_global_stats)
                .SetParam("output_mean_var", output_mean_var)
                .SetParam("axis", axis)
                .SetParam("cudnn_off", cudnn_off)
                .Invoke(@out);
        }

        public static NDArrayList Concat(NDArrayList data, int num_args, int dim, NDArrayList @out = null)
        {
            return new Operator("Concat")
                .SetInput(data)
                .SetParam("num_args", num_args)
                .SetParam("dim", dim)
                .Invoke(@out);
        }

        public static NDArrayList Convolution(NDArray data, NDArray weight, NDArray bias, Shape kernel, Shape stride, Shape dilate, Shape pad, int num_filter, int num_group, long workspace, bool no_bias, string cudnn_tune, bool cudnn_off, string layout, NDArrayList @out = null)
        {
            return new Operator("Convolution")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("kernel", kernel)
                .SetParam("stride", stride)
                .SetParam("dilate", dilate)
                .SetParam("pad", pad)
                .SetParam("num_filter", num_filter)
                .SetParam("num_group", num_group)
                .SetParam("workspace", workspace)
                .SetParam("no_bias", no_bias)
                .SetParam("cudnn_tune", cudnn_tune)
                .SetParam("cudnn_off", cudnn_off)
                .SetParam("layout", layout)
                .Invoke(@out);
        }

        public static NDArrayList CTCLoss(NDArray data, NDArray label, NDArray data_lengths, NDArray label_lengths, bool use_data_lengths, bool use_label_lengths, string blank_label, NDArrayList @out = null)
        {
            return new Operator("CTCLoss")
                .SetInput(data)
                .SetInput(label)
                .SetInput(data_lengths)
                .SetInput(label_lengths)
                .SetParam("use_data_lengths", use_data_lengths)
                .SetParam("use_label_lengths", use_label_lengths)
                .SetParam("blank_label", blank_label)
                .Invoke(@out);
        }

        public static NDArrayList Deconvolution(NDArray data, NDArray weight, NDArray bias, Shape kernel, Shape stride, Shape dilate, Shape pad, Shape adj, Shape target_shape, int num_filter, int num_group, long workspace, bool no_bias, string cudnn_tune, bool cudnn_off, string layout, NDArrayList @out = null)
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
                .SetParam("target_shape", target_shape)
                .SetParam("num_filter", num_filter)
                .SetParam("num_group", num_group)
                .SetParam("workspace", workspace)
                .SetParam("no_bias", no_bias)
                .SetParam("cudnn_tune", cudnn_tune)
                .SetParam("cudnn_off", cudnn_off)
                .SetParam("layout", layout)
                .Invoke(@out);
        }

        public static NDArrayList Dropout(NDArray data, float p, string mode, Shape axes, bool cudnn_off, NDArrayList @out = null)
        {
            return new Operator("Dropout")
                .SetInput(data)
                .SetParam("p", p)
                .SetParam("mode", mode)
                .SetParam("axes", axes)
                .SetParam("cudnn_off", cudnn_off)
                .Invoke(@out);
        }

        public static NDArrayList FullyConnected(NDArray data, NDArray weight, NDArray bias, int num_hidden, bool no_bias, bool flatten, NDArrayList @out = null)
        {
            return new Operator("FullyConnected")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("num_hidden", num_hidden)
                .SetParam("no_bias", no_bias)
                .SetParam("flatten", flatten)
                .Invoke(@out);
        }

        public static NDArrayList LayerNorm(NDArray data, NDArray gamma, NDArray beta, int axis, float eps, bool output_mean_var, NDArrayList @out = null)
        {
            return new Operator("LayerNorm")
                .SetInput(data)
                .SetInput(gamma)
                .SetInput(beta)
                .SetParam("axis", axis)
                .SetParam("eps", eps)
                .SetParam("output_mean_var", output_mean_var)
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

        public static NDArrayList Pooling(NDArray data, Shape kernel, string pool_type, bool global_pool, bool cudnn_off, string pooling_convention, Shape stride, Shape pad, int p_value, bool count_include_pad, string layout, NDArrayList @out = null)
        {
            return new Operator("Pooling")
                .SetInput(data)
                .SetParam("kernel", kernel)
                .SetParam("pool_type", pool_type)
                .SetParam("global_pool", global_pool)
                .SetParam("cudnn_off", cudnn_off)
                .SetParam("pooling_convention", pooling_convention)
                .SetParam("stride", stride)
                .SetParam("pad", pad)
                .SetParam("p_value", p_value)
                .SetParam("count_include_pad", count_include_pad)
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

        public static NDArrayList UpSampling(NDArrayList data, int scale, int num_filter, string sample_type, string multi_input_mode, int num_args, long workspace, NDArrayList @out = null)
        {
            return new Operator("UpSampling")
                .SetInput(data)
                .SetParam("scale", scale)
                .SetParam("num_filter", num_filter)
                .SetParam("sample_type", sample_type)
                .SetParam("multi_input_mode", multi_input_mode)
                .SetParam("num_args", num_args)
                .SetParam("workspace", workspace)
                .Invoke(@out);
        }

        public static NDArrayList SignsgdUpdate(NDArray weight, NDArray grad, float lr, float wd, float rescale_grad, float clip_gradient, NDArrayList @out = null)
        {
            return new Operator("signsgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .Invoke(@out);
        }

        public static NDArrayList SignumUpdate(NDArray weight, NDArray grad, NDArray mom, float lr, float momentum, float wd, float rescale_grad, float clip_gradient, float wd_lh, NDArrayList @out = null)
        {
            return new Operator("signum_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("wd_lh", wd_lh)
                .Invoke(@out);
        }

        public static NDArrayList MultiSgdUpdate(NDArrayList data, object lrs, object wds, float rescale_grad, float clip_gradient, int num_weights, NDArrayList @out = null)
        {
            return new Operator("multi_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("num_weights", num_weights)
                .Invoke(@out);
        }

        public static NDArrayList MultiSgdMomUpdate(NDArrayList data, object lrs, object wds, float momentum, float rescale_grad, float clip_gradient, int num_weights, NDArrayList @out = null)
        {
            return new Operator("multi_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("num_weights", num_weights)
                .Invoke(@out);
        }

        public static NDArrayList MultiMpSgdUpdate(NDArrayList data, object lrs, object wds, float rescale_grad, float clip_gradient, int num_weights, NDArrayList @out = null)
        {
            return new Operator("multi_mp_sgd_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("num_weights", num_weights)
                .Invoke(@out);
        }

        public static NDArrayList MultiMpSgdMomUpdate(NDArrayList data, object lrs, object wds, float momentum, float rescale_grad, float clip_gradient, int num_weights, NDArrayList @out = null)
        {
            return new Operator("multi_mp_sgd_mom_update")
                .SetInput(data)
                .SetParam("lrs", lrs)
                .SetParam("wds", wds)
                .SetParam("momentum", momentum)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("num_weights", num_weights)
                .Invoke(@out);
        }

        public static NDArrayList SgdUpdate(NDArray weight, NDArray grad, float lr, float wd, float rescale_grad, float clip_gradient, bool lazy_update, NDArrayList @out = null)
        {
            return new Operator("sgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("lazy_update", lazy_update)
                .Invoke(@out);
        }

        public static NDArrayList SgdMomUpdate(NDArray weight, NDArray grad, NDArray mom, float lr, float momentum, float wd, float rescale_grad, float clip_gradient, bool lazy_update, NDArrayList @out = null)
        {
            return new Operator("sgd_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("lazy_update", lazy_update)
                .Invoke(@out);
        }

        public static NDArrayList MpSgdUpdate(NDArray weight, NDArray grad, NDArray weight32, float lr, float wd, float rescale_grad, float clip_gradient, bool lazy_update, NDArrayList @out = null)
        {
            return new Operator("mp_sgd_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(weight32)
                .SetParam("lr", lr)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("lazy_update", lazy_update)
                .Invoke(@out);
        }

        public static NDArrayList MpSgdMomUpdate(NDArray weight, NDArray grad, NDArray mom, NDArray weight32, float lr, float momentum, float wd, float rescale_grad, float clip_gradient, bool lazy_update, NDArrayList @out = null)
        {
            return new Operator("mp_sgd_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetInput(weight32)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("lazy_update", lazy_update)
                .Invoke(@out);
        }

        public static NDArrayList FtmlUpdate(NDArray weight, NDArray grad, NDArray d, NDArray v, NDArray z, float lr, float beta1, float beta2, double epsilon, int t, float wd, float rescale_grad, float clip_grad, NDArrayList @out = null)
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
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_grad", clip_grad)
                .Invoke(@out);
        }

        public static NDArrayList AdamUpdate(NDArray weight, NDArray grad, NDArray mean, NDArray var, float lr, float beta1, float beta2, float epsilon, float wd, float rescale_grad, float clip_gradient, bool lazy_update, NDArrayList @out = null)
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
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("lazy_update", lazy_update)
                .Invoke(@out);
        }

        public static NDArrayList NagMomUpdate(NDArray weight, NDArray grad, NDArray mom, float lr, float momentum, float wd, float rescale_grad, float clip_gradient, NDArrayList @out = null)
        {
            return new Operator("nag_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .Invoke(@out);
        }

        public static NDArrayList MpNagMomUpdate(NDArray weight, NDArray grad, NDArray mom, NDArray weight32, float lr, float momentum, float wd, float rescale_grad, float clip_gradient, NDArrayList @out = null)
        {
            return new Operator("mp_nag_mom_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mom)
                .SetInput(weight32)
                .SetParam("lr", lr)
                .SetParam("momentum", momentum)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .Invoke(@out);
        }

        public static NDArrayList RmspropUpdate(NDArray weight, NDArray grad, NDArray n, float lr, float gamma1, float epsilon, float wd, float rescale_grad, float clip_gradient, float clip_weights, NDArrayList @out = null)
        {
            return new Operator("rmsprop_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(n)
                .SetParam("lr", lr)
                .SetParam("gamma1", gamma1)
                .SetParam("epsilon", epsilon)
                .SetParam("wd", wd)
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("clip_weights", clip_weights)
                .Invoke(@out);
        }

        public static NDArrayList RmspropalexUpdate(NDArray weight, NDArray grad, NDArray n, NDArray g, NDArray delta, float lr, float gamma1, float gamma2, float epsilon, float wd, float rescale_grad, float clip_gradient, float clip_weights, NDArrayList @out = null)
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
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .SetParam("clip_weights", clip_weights)
                .Invoke(@out);
        }

        public static NDArrayList FtrlUpdate(NDArray weight, NDArray grad, NDArray z, NDArray n, float lr, float lamda1, float beta, float wd, float rescale_grad, float clip_gradient, NDArrayList @out = null)
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
                .SetParam("rescale_grad", rescale_grad)
                .SetParam("clip_gradient", clip_gradient)
                .Invoke(@out);
        }

        public static NDArrayList Pad(NDArray data, string mode, Shape pad_width, double constant_value, NDArrayList @out = null)
        {
            return new Operator("Pad")
                .SetInput(data)
                .SetParam("mode", mode)
                .SetParam("pad_width", pad_width)
                .SetParam("constant_value", constant_value)
                .Invoke(@out);
        }

        public static NDArrayList Flatten(NDArray data, NDArrayList @out = null)
        {
            return new Operator("Flatten")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList LinearRegressionOutput(NDArray data, NDArray label, float grad_scale, NDArrayList @out = null)
        {
            return new Operator("LinearRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", grad_scale)
                .Invoke(@out);
        }

        public static NDArrayList MAERegressionOutput(NDArray data, NDArray label, float grad_scale, NDArrayList @out = null)
        {
            return new Operator("MAERegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", grad_scale)
                .Invoke(@out);
        }

        public static NDArrayList LogisticRegressionOutput(NDArray data, NDArray label, float grad_scale, NDArrayList @out = null)
        {
            return new Operator("LogisticRegressionOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", grad_scale)
                .Invoke(@out);
        }

        public static NDArrayList RNN(NDArray data, NDArray parameters, NDArray state, NDArray state_cell, NDArray sequence_length, int state_size, int num_layers, bool bidirectional, string mode, float p, bool state_outputs, int projection_size, double lstm_state_clip_min, double lstm_state_clip_max, bool lstm_state_clip_nan, bool use_sequence_length, NDArrayList @out = null)
        {
            return new Operator("RNN")
                .SetInput(data)
                .SetInput(parameters)
                .SetInput(state)
                .SetInput(state_cell)
                .SetInput(sequence_length)
                .SetParam("state_size", state_size)
                .SetParam("num_layers", num_layers)
                .SetParam("bidirectional", bidirectional)
                .SetParam("mode", mode)
                .SetParam("p", p)
                .SetParam("state_outputs", state_outputs)
                .SetParam("projection_size", projection_size)
                .SetParam("lstm_state_clip_min", lstm_state_clip_min)
                .SetParam("lstm_state_clip_max", lstm_state_clip_max)
                .SetParam("lstm_state_clip_nan", lstm_state_clip_nan)
                .SetParam("use_sequence_length", use_sequence_length)
                .Invoke(@out);
        }

        public static NDArrayList SliceChannel(NDArray data, int num_outputs, int axis, bool squeeze_axis, NDArrayList @out = null)
        {
            return new Operator("SliceChannel")
                .SetInput(data)
                .SetParam("num_outputs", num_outputs)
                .SetParam("axis", axis)
                .SetParam("squeeze_axis", squeeze_axis)
                .Invoke(@out);
        }

        public static NDArrayList SoftmaxOutput(NDArray data, NDArray label, float grad_scale, float ignore_label, bool multi_output, bool use_ignore, bool preserve_shape, string normalization, bool out_grad, float smooth_alpha, NDArrayList @out = null)
        {
            return new Operator("SoftmaxOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("grad_scale", grad_scale)
                .SetParam("ignore_label", ignore_label)
                .SetParam("multi_output", multi_output)
                .SetParam("use_ignore", use_ignore)
                .SetParam("preserve_shape", preserve_shape)
                .SetParam("normalization", normalization)
                .SetParam("out_grad", out_grad)
                .SetParam("smooth_alpha", smooth_alpha)
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

        public static NDArrayList AmpMulticast(NDArrayList data, int num_outputs, NDArrayList @out = null)
        {
            return new Operator("amp_multicast")
                .SetInput(data)
                .SetParam("num_outputs", num_outputs)
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

        public static NDArrayList BroadcastLike(NDArray lhs, NDArray rhs, Shape lhs_axes, Shape rhs_axes, NDArrayList @out = null)
        {
            return new Operator("broadcast_like")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("lhs_axes", lhs_axes)
                .SetParam("rhs_axes", rhs_axes)
                .Invoke(@out);
        }

        public static NDArrayList Norm(NDArray data, int ord, Shape axis, string out_dtype, bool keepdims, NDArrayList @out = null)
        {
            return new Operator("norm")
                .SetInput(data)
                .SetParam("ord", ord)
                .SetParam("axis", axis)
                .SetParam("out_dtype", out_dtype)
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

        public static NDArrayList Dot(NDArray lhs, NDArray rhs, bool transpose_a, bool transpose_b, string forward_stype, NDArrayList @out = null)
        {
            return new Operator("dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transpose_a", transpose_a)
                .SetParam("transpose_b", transpose_b)
                .SetParam("forward_stype", forward_stype)
                .Invoke(@out);
        }

        public static NDArrayList BatchDot(NDArray lhs, NDArray rhs, bool transpose_a, bool transpose_b, string forward_stype, NDArrayList @out = null)
        {
            return new Operator("batch_dot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("transpose_a", transpose_a)
                .SetParam("transpose_b", transpose_b)
                .SetParam("forward_stype", forward_stype)
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

        public static NDArrayList ShapeArray(NDArray data, int lhs_begin, int lhs_end, int rhs_begin, int rhs_end, NDArrayList @out = null)
        {
            return new Operator("shape_array")
                .SetInput(data)
                .SetParam("lhs_begin", lhs_begin)
                .SetParam("lhs_end", lhs_end)
                .SetParam("rhs_begin", rhs_begin)
                .SetParam("rhs_end", rhs_end)
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

        public static NDArrayList Embedding(NDArray data, NDArray weight, int input_dim, int output_dim, string dtype, bool sparse_grad, NDArrayList @out = null)
        {
            return new Operator("Embedding")
                .SetInput(data)
                .SetInput(weight)
                .SetParam("input_dim", input_dim)
                .SetParam("output_dim", output_dim)
                .SetParam("dtype", dtype)
                .SetParam("sparse_grad", sparse_grad)
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

        public static NDArrayList OneHot(NDArray indices, int depth, double on_value, double off_value, string dtype, NDArrayList @out = null)
        {
            return new Operator("one_hot")
                .SetInput(indices)
                .SetParam("depth", depth)
                .SetParam("on_value", on_value)
                .SetParam("off_value", off_value)
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

        public static NDArrayList Reshape(NDArray data, Shape shape, bool reverse, Shape target_shape, bool keep_highest, NDArrayList @out = null)
        {
            return new Operator("Reshape")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("reverse", reverse)
                .SetParam("target_shape", target_shape)
                .SetParam("keep_highest", keep_highest)
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

        public static NDArrayList SliceLike(NDArray data, NDArray shape_like, Shape axes, NDArrayList @out = null)
        {
            return new Operator("slice_like")
                .SetInput(data)
                .SetInput(shape_like)
                .SetParam("axes", axes)
                .Invoke(@out);
        }

        public static NDArrayList Clip(NDArray data, float a_min, float a_max, NDArrayList @out = null)
        {
            return new Operator("clip")
                .SetInput(data)
                .SetParam("a_min", a_min)
                .SetParam("a_max", a_max)
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

        public static NDArrayList Stack(NDArrayList data, int axis, int num_args, NDArrayList @out = null)
        {
            return new Operator("stack")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("num_args", num_args)
                .Invoke(@out);
        }

        public static NDArrayList Squeeze(NDArrayList data, Shape axis, NDArrayList @out = null)
        {
            return new Operator("squeeze")
                .SetInput(data)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList DepthToSpace(NDArray data, int block_size, NDArrayList @out = null)
        {
            return new Operator("depth_to_space")
                .SetInput(data)
                .SetParam("block_size", block_size)
                .Invoke(@out);
        }

        public static NDArrayList SpaceToDepth(NDArray data, int block_size, NDArrayList @out = null)
        {
            return new Operator("space_to_depth")
                .SetInput(data)
                .SetParam("block_size", block_size)
                .Invoke(@out);
        }

        public static NDArrayList Topk(NDArray data, int axis, int k, string ret_typ, bool is_ascend, string dtype, NDArrayList @out = null)
        {
            return new Operator("topk")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("k", k)
                .SetParam("ret_typ", ret_typ)
                .SetParam("is_ascend", is_ascend)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList Sort(NDArray data, int axis, bool is_ascend, NDArrayList @out = null)
        {
            return new Operator("sort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("is_ascend", is_ascend)
                .Invoke(@out);
        }

        public static NDArrayList Argsort(NDArray data, int axis, bool is_ascend, string dtype, NDArrayList @out = null)
        {
            return new Operator("argsort")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("is_ascend", is_ascend)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList BilinearSampler(NDArray data, NDArray grid, bool cudnn_off, NDArrayList @out = null)
        {
            return new Operator("BilinearSampler")
                .SetInput(data)
                .SetInput(grid)
                .SetParam("cudnn_off", cudnn_off)
                .Invoke(@out);
        }

        public static NDArrayList ConvolutionV1(NDArray data, NDArray weight, NDArray bias, Shape kernel, Shape stride, Shape dilate, Shape pad, int num_filter, int num_group, long workspace, bool no_bias, string cudnn_tune, bool cudnn_off, string layout, NDArrayList @out = null)
        {
            return new Operator("Convolution_v1")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("kernel", kernel)
                .SetParam("stride", stride)
                .SetParam("dilate", dilate)
                .SetParam("pad", pad)
                .SetParam("num_filter", num_filter)
                .SetParam("num_group", num_group)
                .SetParam("workspace", workspace)
                .SetParam("no_bias", no_bias)
                .SetParam("cudnn_tune", cudnn_tune)
                .SetParam("cudnn_off", cudnn_off)
                .SetParam("layout", layout)
                .Invoke(@out);
        }

        public static NDArrayList Correlation(NDArray data1, NDArray data2, int kernel_size, int max_displacement, int stride1, int stride2, int pad_size, bool is_multiply, NDArrayList @out = null)
        {
            return new Operator("Correlation")
                .SetInput(data1)
                .SetInput(data2)
                .SetParam("kernel_size", kernel_size)
                .SetParam("max_displacement", max_displacement)
                .SetParam("stride1", stride1)
                .SetParam("stride2", stride2)
                .SetParam("pad_size", pad_size)
                .SetParam("is_multiply", is_multiply)
                .Invoke(@out);
        }

        public static NDArrayList Crop(SymbolList data, int num_args, Shape offset, Shape h_w, bool center_crop, NDArrayList @out = null)
        {
            return new Operator("Crop")
                .SetInput(data)
                .SetParam("num_args", num_args)
                .SetParam("offset", offset)
                .SetParam("h_w", h_w)
                .SetParam("center_crop", center_crop)
                .Invoke(@out);
        }

        public static NDArrayList GridGenerator(NDArray data, string transform_type, Shape target_shape, NDArrayList @out = null)
        {
            return new Operator("GridGenerator")
                .SetInput(data)
                .SetParam("transform_type", transform_type)
                .SetParam("target_shape", target_shape)
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

        public static NDArrayList MakeLoss(NDArray data, float grad_scale, float valid_thresh, string normalization, NDArrayList @out = null)
        {
            return new Operator("MakeLoss")
                .SetInput(data)
                .SetParam("grad_scale", grad_scale)
                .SetParam("valid_thresh", valid_thresh)
                .SetParam("normalization", normalization)
                .Invoke(@out);
        }

        public static NDArrayList PoolingV1(NDArray data, Shape kernel, string pool_type, bool global_pool, string pooling_convention, Shape stride, Shape pad, NDArrayList @out = null)
        {
            return new Operator("Pooling_v1")
                .SetInput(data)
                .SetParam("kernel", kernel)
                .SetParam("pool_type", pool_type)
                .SetParam("global_pool", global_pool)
                .SetParam("pooling_convention", pooling_convention)
                .SetParam("stride", stride)
                .SetParam("pad", pad)
                .Invoke(@out);
        }

        public static NDArrayList ROIPooling(NDArray data, NDArray rois, Shape pooled_size, float spatial_scale, NDArrayList @out = null)
        {
            return new Operator("ROIPooling")
                .SetInput(data)
                .SetInput(rois)
                .SetParam("pooled_size", pooled_size)
                .SetParam("spatial_scale", spatial_scale)
                .Invoke(@out);
        }

        public static NDArrayList SequenceLast(NDArray data, NDArray sequence_length, bool use_sequence_length, int axis, NDArrayList @out = null)
        {
            return new Operator("SequenceLast")
                .SetInput(data)
                .SetInput(sequence_length)
                .SetParam("use_sequence_length", use_sequence_length)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList SequenceMask(NDArray data, NDArray sequence_length, bool use_sequence_length, float value, int axis, NDArrayList @out = null)
        {
            return new Operator("SequenceMask")
                .SetInput(data)
                .SetInput(sequence_length)
                .SetParam("use_sequence_length", use_sequence_length)
                .SetParam("value", value)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList SequenceReverse(NDArray data, NDArray sequence_length, bool use_sequence_length, int axis, NDArrayList @out = null)
        {
            return new Operator("SequenceReverse")
                .SetInput(data)
                .SetInput(sequence_length)
                .SetParam("use_sequence_length", use_sequence_length)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList SpatialTransformer(NDArray data, NDArray loc, Shape target_shape, string transform_type, string sampler_type, bool cudnn_off, NDArrayList @out = null)
        {
            return new Operator("SpatialTransformer")
                .SetInput(data)
                .SetInput(loc)
                .SetParam("target_shape", target_shape)
                .SetParam("transform_type", transform_type)
                .SetParam("sampler_type", sampler_type)
                .SetParam("cudnn_off", cudnn_off)
                .Invoke(@out);
        }

        public static NDArrayList SVMOutput(NDArray data, NDArray label, float margin, float regularization_coefficient, bool use_linear, NDArrayList @out = null)
        {
            return new Operator("SVMOutput")
                .SetInput(data)
                .SetInput(label)
                .SetParam("margin", margin)
                .SetParam("regularization_coefficient", regularization_coefficient)
                .SetParam("use_linear", use_linear)
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
