using System;
using Horker.MXNet;
using Horker.MXNet.Interop;

namespace Horker.MXNet
{
    public partial class NDArray : NDArrayBase
    {
        public static class _internal
        {
        public static NDArrayList _CustomFunction(NDArrayList @out = null)
        {
            return new Operator("_CustomFunction")
                .Invoke(@out);
        }

        public static NDArrayList _backwardCustomFunction(NDArrayList @out = null)
        {
            return new Operator("_backward_CustomFunction")
                .Invoke(@out);
        }

        public static NDArrayList _CachedOp(NDArrayList data, NDArrayList @out = null)
        {
            return new Operator("_CachedOp")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _backwardCachedOp(NDArrayList @out = null)
        {
            return new Operator("_backward_CachedOp")
                .Invoke(@out);
        }

        public static NDArrayList _cvimdecode(NDArray buf, int flag, bool toRgb, NDArrayList @out = null)
        {
            return new Operator("_cvimdecode")
                .SetInput(buf)
                .SetParam("flag", flag)
                .SetParam("toRgb", toRgb)
                .Invoke(@out);
        }

        public static NDArrayList _cvimread(string filename, int flag, bool toRgb, NDArrayList @out = null)
        {
            return new Operator("_cvimread")
                .SetParam("filename", filename)
                .SetParam("flag", flag)
                .SetParam("toRgb", toRgb)
                .Invoke(@out);
        }

        public static NDArrayList _cvimresize(NDArray src, int w, int h, int interp, NDArrayList @out = null)
        {
            return new Operator("_cvimresize")
                .SetInput(src)
                .SetParam("w", w)
                .SetParam("h", h)
                .SetParam("interp", interp)
                .Invoke(@out);
        }

        public static NDArrayList _cvcopyMakeBorder(NDArray src, int top, int bot, int left, int right, int type, double value, object values, NDArrayList @out = null)
        {
            return new Operator("_cvcopyMakeBorder")
                .SetInput(src)
                .SetParam("top", top)
                .SetParam("bot", bot)
                .SetParam("left", left)
                .SetParam("right", right)
                .SetParam("type", type)
                .SetParam("value", value)
                .SetParam("values", values)
                .Invoke(@out);
        }

        public static NDArrayList _copyto(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_copyto")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _NoGradient(NDArrayList @out = null)
        {
            return new Operator("_NoGradient")
                .Invoke(@out);
        }

        public static NDArrayList _mpAdamwUpdate(NDArray weight, NDArray grad, NDArray mean, NDArray var, NDArray weight32, NDArray rescaleGrad, float lr, float beta1, float beta2, float epsilon, float wd, float eta, float clipGradient, NDArrayList @out = null)
        {
            return new Operator("_mp_adamw_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mean)
                .SetInput(var)
                .SetInput(weight32)
                .SetInput(rescaleGrad)
                .SetParam("lr", lr)
                .SetParam("beta1", beta1)
                .SetParam("beta2", beta2)
                .SetParam("epsilon", epsilon)
                .SetParam("wd", wd)
                .SetParam("eta", eta)
                .SetParam("clipGradient", clipGradient)
                .Invoke(@out);
        }

        public static NDArrayList _adamwUpdate(NDArray weight, NDArray grad, NDArray mean, NDArray var, NDArray rescaleGrad, float lr, float beta1, float beta2, float epsilon, float wd, float eta, float clipGradient, NDArrayList @out = null)
        {
            return new Operator("_adamw_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(mean)
                .SetInput(var)
                .SetInput(rescaleGrad)
                .SetParam("lr", lr)
                .SetParam("beta1", beta1)
                .SetParam("beta2", beta2)
                .SetParam("epsilon", epsilon)
                .SetParam("wd", wd)
                .SetParam("eta", eta)
                .SetParam("clipGradient", clipGradient)
                .Invoke(@out);
        }

        public static NDArrayList _contribAdaptiveAvgPooling2D(NDArray data, Shape outputSize, NDArrayList @out = null)
        {
            return new Operator("_contrib_AdaptiveAvgPooling2D")
                .SetInput(data)
                .SetParam("outputSize", outputSize)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribAdaptiveAvgPooling2D(NDArrayList @out = null)
        {
            return new Operator("_backward_contrib_AdaptiveAvgPooling2D")
                .Invoke(@out);
        }

        public static NDArrayList _contribBilinearResize2D(NDArray data, NDArray like, int height, int width, float scaleHeight, float scaleWidth, string mode, NDArrayList @out = null)
        {
            return new Operator("_contrib_BilinearResize2D")
                .SetInput(data)
                .SetInput(like)
                .SetParam("height", height)
                .SetParam("width", width)
                .SetParam("scaleHeight", scaleHeight)
                .SetParam("scaleWidth", scaleWidth)
                .SetParam("mode", mode)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribBilinearResize2D(NDArrayList @out = null)
        {
            return new Operator("_backward_contrib_BilinearResize2D")
                .Invoke(@out);
        }

        public static NDArrayList _contribBooleanMask(NDArray data, NDArray index, int axis, NDArrayList @out = null)
        {
            return new Operator("_contrib_boolean_mask")
                .SetInput(data)
                .SetInput(index)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribBooleanMask(int axis, NDArrayList @out = null)
        {
            return new Operator("_backward_contrib_boolean_mask")
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList _contribBoxNms(NDArray data, float overlapThresh, float validThresh, int topk, int coordStart, int scoreIndex, int idIndex, int backgroundId, bool forceSuppress, string inFormat, string outFormat, NDArrayList @out = null)
        {
            return new Operator("_contrib_box_nms")
                .SetInput(data)
                .SetParam("overlapThresh", overlapThresh)
                .SetParam("validThresh", validThresh)
                .SetParam("topk", topk)
                .SetParam("coordStart", coordStart)
                .SetParam("scoreIndex", scoreIndex)
                .SetParam("idIndex", idIndex)
                .SetParam("backgroundId", backgroundId)
                .SetParam("forceSuppress", forceSuppress)
                .SetParam("inFormat", inFormat)
                .SetParam("outFormat", outFormat)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribBoxNms(float overlapThresh, float validThresh, int topk, int coordStart, int scoreIndex, int idIndex, int backgroundId, bool forceSuppress, string inFormat, string outFormat, NDArrayList @out = null)
        {
            return new Operator("_backward_contrib_box_nms")
                .SetParam("overlapThresh", overlapThresh)
                .SetParam("validThresh", validThresh)
                .SetParam("topk", topk)
                .SetParam("coordStart", coordStart)
                .SetParam("scoreIndex", scoreIndex)
                .SetParam("idIndex", idIndex)
                .SetParam("backgroundId", backgroundId)
                .SetParam("forceSuppress", forceSuppress)
                .SetParam("inFormat", inFormat)
                .SetParam("outFormat", outFormat)
                .Invoke(@out);
        }

        public static NDArrayList _contribBoxIou(NDArray lhs, NDArray rhs, string format, NDArrayList @out = null)
        {
            return new Operator("_contrib_box_iou")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("format", format)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribBoxIou(string format, NDArrayList @out = null)
        {
            return new Operator("_backward_contrib_box_iou")
                .SetParam("format", format)
                .Invoke(@out);
        }

        public static NDArrayList _contribBipartiteMatching(NDArray data, bool isAscend, float threshold, int topk, NDArrayList @out = null)
        {
            return new Operator("_contrib_bipartite_matching")
                .SetInput(data)
                .SetParam("isAscend", isAscend)
                .SetParam("threshold", threshold)
                .SetParam("topk", topk)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribBipartiteMatching(bool isAscend, float threshold, int topk, NDArrayList @out = null)
        {
            return new Operator("_backward_contrib_bipartite_matching")
                .SetParam("isAscend", isAscend)
                .SetParam("threshold", threshold)
                .SetParam("topk", topk)
                .Invoke(@out);
        }

        public static NDArrayList _contribDglCsrNeighborUniformSample(NDArray csrMatrix, NDArrayList seedArrays, int numArgs, object numHops, object numNeighbor, object maxNumVertices, NDArrayList @out = null)
        {
            return new Operator("_contrib_dgl_csr_neighbor_uniform_sample")
                .SetInput(csrMatrix)
                .SetInput(seedArrays)
                .SetParam("numArgs", numArgs)
                .SetParam("numHops", numHops)
                .SetParam("numNeighbor", numNeighbor)
                .SetParam("maxNumVertices", maxNumVertices)
                .Invoke(@out);
        }

        public static NDArrayList _contribDglCsrNeighborNonUniformSample(NDArray csrMatrix, NDArray probability, NDArrayList seedArrays, int numArgs, object numHops, object numNeighbor, object maxNumVertices, NDArrayList @out = null)
        {
            return new Operator("_contrib_dgl_csr_neighbor_non_uniform_sample")
                .SetInput(csrMatrix)
                .SetInput(probability)
                .SetInput(seedArrays)
                .SetParam("numArgs", numArgs)
                .SetParam("numHops", numHops)
                .SetParam("numNeighbor", numNeighbor)
                .SetParam("maxNumVertices", maxNumVertices)
                .Invoke(@out);
        }

        public static NDArrayList _contribDglSubgraph(NDArray graph, NDArrayList data, int numArgs, bool returnMapping, NDArrayList @out = null)
        {
            return new Operator("_contrib_dgl_subgraph")
                .SetInput(graph)
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("returnMapping", returnMapping)
                .Invoke(@out);
        }

        public static NDArrayList _contribEdgeId(NDArray data, NDArray u, NDArray v, NDArrayList @out = null)
        {
            return new Operator("_contrib_edge_id")
                .SetInput(data)
                .SetInput(u)
                .SetInput(v)
                .Invoke(@out);
        }

        public static NDArrayList _contribDglAdjacency(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_contrib_dgl_adjacency")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _contribDglGraphCompact(NDArrayList graphData, int numArgs, bool returnMapping, object graphSizes, NDArrayList @out = null)
        {
            return new Operator("_contrib_dgl_graph_compact")
                .SetInput(graphData)
                .SetParam("numArgs", numArgs)
                .SetParam("returnMapping", returnMapping)
                .SetParam("graphSizes", graphSizes)
                .Invoke(@out);
        }

        public static NDArrayList _contribGradientmultiplier(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_contrib_gradientmultiplier")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _contribBackwardGradientmultiplier(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_contrib_backward_gradientmultiplier")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _contribHawkesll(NDArray lda, NDArray alpha, NDArray beta, NDArray state, NDArray lags, NDArray marks, NDArray validLength, NDArray maxTime, NDArrayList @out = null)
        {
            return new Operator("_contrib_hawkesll")
                .SetInput(lda)
                .SetInput(alpha)
                .SetInput(beta)
                .SetInput(state)
                .SetInput(lags)
                .SetInput(marks)
                .SetInput(validLength)
                .SetInput(maxTime)
                .Invoke(@out);
        }

        public static NDArrayList _contribBackwardHawkesll(NDArrayList @out = null)
        {
            return new Operator("_contrib_backward_hawkesll")
                .Invoke(@out);
        }

        public static NDArrayList _contribIndexArray(NDArray data, Shape axes, NDArrayList @out = null)
        {
            return new Operator("_contrib_index_array")
                .SetInput(data)
                .SetParam("axes", axes)
                .Invoke(@out);
        }

        public static NDArrayList _contribIndexCopy(NDArray oldTensor, NDArray indexVector, NDArray newTensor, NDArrayList @out = null)
        {
            return new Operator("_contrib_index_copy")
                .SetInput(oldTensor)
                .SetInput(indexVector)
                .SetInput(newTensor)
                .Invoke(@out);
        }

        public static NDArrayList _contribBackwardIndexCopy(NDArrayList @out = null)
        {
            return new Operator("_contrib_backward_index_copy")
                .Invoke(@out);
        }

        public static NDArrayList _contribGetnnz(NDArray data, int axis, NDArrayList @out = null)
        {
            return new Operator("_contrib_getnnz")
                .SetInput(data)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList _contribGroupAdagradUpdate(NDArray weight, NDArray grad, NDArray history, float lr, float rescaleGrad, float clipGradient, float epsilon, NDArrayList @out = null)
        {
            return new Operator("_contrib_group_adagrad_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(history)
                .SetParam("lr", lr)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("epsilon", epsilon)
                .Invoke(@out);
        }

        public static NDArrayList _contribQuadratic(NDArray data, float a, float b, float c, NDArrayList @out = null)
        {
            return new Operator("_contrib_quadratic")
                .SetInput(data)
                .SetParam("a", a)
                .SetParam("b", b)
                .SetParam("c", c)
                .Invoke(@out);
        }

        public static NDArrayList _contribBackwardQuadratic(NDArrayList @out = null)
        {
            return new Operator("_contrib_backward_quadratic")
                .Invoke(@out);
        }

        public static NDArrayList _contribROIAlign(NDArray data, NDArray rois, Shape pooledSize, float spatialScale, int sampleRatio, bool positionSensitive, NDArrayList @out = null)
        {
            return new Operator("_contrib_ROIAlign")
                .SetInput(data)
                .SetInput(rois)
                .SetParam("pooledSize", pooledSize)
                .SetParam("spatialScale", spatialScale)
                .SetParam("sampleRatio", sampleRatio)
                .SetParam("positionSensitive", positionSensitive)
                .Invoke(@out);
        }

        public static NDArrayList _backwardROIAlign(NDArrayList @out = null)
        {
            return new Operator("_backward_ROIAlign")
                .Invoke(@out);
        }

        public static NDArrayList _contribSyncBatchNorm(NDArray data, NDArray gamma, NDArray beta, NDArray movingMean, NDArray movingVar, float eps, float momentum, bool fixGamma, bool useGlobalStats, bool outputMeanVar, int ndev, string key, NDArrayList @out = null)
        {
            return new Operator("_contrib_SyncBatchNorm")
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
                .SetParam("ndev", ndev)
                .SetParam("key", key)
                .Invoke(@out);
        }

        public static NDArrayList _contribDivSqrtDim(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_contrib_div_sqrt_dim")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _foreach(Symbol fn, NDArrayList data, int numArgs, int numOutputs, int numOutData, object inStateLocs, object inDataLocs, object remainLocs, NDArrayList @out = null)
        {
            return new Operator("_foreach")
                .SetInput(fn)
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("numOutputs", numOutputs)
                .SetParam("numOutData", numOutData)
                .SetParam("inStateLocs", inStateLocs)
                .SetParam("inDataLocs", inDataLocs)
                .SetParam("remainLocs", remainLocs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardForeach(NDArrayList @out = null)
        {
            return new Operator("_backward_foreach")
                .Invoke(@out);
        }

        public static NDArrayList _whileLoop(Symbol cond, Symbol func, NDArrayList data, int numArgs, int numOutputs, int numOutData, int maxIterations, object condInputLocs, object funcInputLocs, object funcVarLocs, NDArrayList @out = null)
        {
            return new Operator("_while_loop")
                .SetInput(cond)
                .SetInput(func)
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("numOutputs", numOutputs)
                .SetParam("numOutData", numOutData)
                .SetParam("maxIterations", maxIterations)
                .SetParam("condInputLocs", condInputLocs)
                .SetParam("funcInputLocs", funcInputLocs)
                .SetParam("funcVarLocs", funcVarLocs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardWhileLoop(NDArrayList @out = null)
        {
            return new Operator("_backward_while_loop")
                .Invoke(@out);
        }

        public static NDArrayList _cond(Symbol cond, Symbol thenBranch, Symbol elseBranch, NDArrayList data, int numArgs, int numOutputs, object condInputLocs, object thenInputLocs, object elseInputLocs, NDArrayList @out = null)
        {
            return new Operator("_cond")
                .SetInput(cond)
                .SetInput(thenBranch)
                .SetInput(elseBranch)
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("numOutputs", numOutputs)
                .SetParam("condInputLocs", condInputLocs)
                .SetParam("thenInputLocs", thenInputLocs)
                .SetParam("elseInputLocs", elseInputLocs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardCond(NDArrayList @out = null)
        {
            return new Operator("_backward_cond")
                .Invoke(@out);
        }

        public static NDArrayList _backwardCustom(NDArrayList @out = null)
        {
            return new Operator("_backward_Custom")
                .Invoke(@out);
        }

        public static NDArrayList _imageCrop(NDArray data, int x, int y, int width, int height, NDArrayList @out = null)
        {
            return new Operator("_image_crop")
                .SetInput(data)
                .SetParam("x", x)
                .SetParam("y", y)
                .SetParam("width", width)
                .SetParam("height", height)
                .Invoke(@out);
        }

        public static NDArrayList _backwardImageCrop(NDArrayList @out = null)
        {
            return new Operator("_backward_image_crop")
                .Invoke(@out);
        }

        public static NDArrayList _imageToTensor(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_image_to_tensor")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _imageNormalize(NDArray data, object mean, object std, NDArrayList @out = null)
        {
            return new Operator("_image_normalize")
                .SetInput(data)
                .SetParam("mean", mean)
                .SetParam("std", std)
                .Invoke(@out);
        }

        public static NDArrayList _backwardImageNormalize(NDArrayList @out = null)
        {
            return new Operator("_backward_image_normalize")
                .Invoke(@out);
        }

        public static NDArrayList _imageFlipLeftRight(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_image_flip_left_right")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _imageRandomFlipLeftRight(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_image_random_flip_left_right")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _imageFlipTopBottom(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_image_flip_top_bottom")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _imageRandomFlipTopBottom(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_image_random_flip_top_bottom")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _imageRandomBrightness(NDArray data, float minFactor, float maxFactor, NDArrayList @out = null)
        {
            return new Operator("_image_random_brightness")
                .SetInput(data)
                .SetParam("minFactor", minFactor)
                .SetParam("maxFactor", maxFactor)
                .Invoke(@out);
        }

        public static NDArrayList _imageRandomContrast(NDArray data, float minFactor, float maxFactor, NDArrayList @out = null)
        {
            return new Operator("_image_random_contrast")
                .SetInput(data)
                .SetParam("minFactor", minFactor)
                .SetParam("maxFactor", maxFactor)
                .Invoke(@out);
        }

        public static NDArrayList _imageRandomSaturation(NDArray data, float minFactor, float maxFactor, NDArrayList @out = null)
        {
            return new Operator("_image_random_saturation")
                .SetInput(data)
                .SetParam("minFactor", minFactor)
                .SetParam("maxFactor", maxFactor)
                .Invoke(@out);
        }

        public static NDArrayList _imageRandomHue(NDArray data, float minFactor, float maxFactor, NDArrayList @out = null)
        {
            return new Operator("_image_random_hue")
                .SetInput(data)
                .SetParam("minFactor", minFactor)
                .SetParam("maxFactor", maxFactor)
                .Invoke(@out);
        }

        public static NDArrayList _imageRandomColorJitter(NDArray data, float brightness, float contrast, float saturation, float hue, NDArrayList @out = null)
        {
            return new Operator("_image_random_color_jitter")
                .SetInput(data)
                .SetParam("brightness", brightness)
                .SetParam("contrast", contrast)
                .SetParam("saturation", saturation)
                .SetParam("hue", hue)
                .Invoke(@out);
        }

        public static NDArrayList _imageAdjustLighting(NDArray data, object alpha, NDArrayList @out = null)
        {
            return new Operator("_image_adjust_lighting")
                .SetInput(data)
                .SetParam("alpha", alpha)
                .Invoke(@out);
        }

        public static NDArrayList _imageRandomLighting(NDArray data, float alphaStd, NDArrayList @out = null)
        {
            return new Operator("_image_random_lighting")
                .SetInput(data)
                .SetParam("alphaStd", alphaStd)
                .Invoke(@out);
        }

        public static NDArrayList _imageResize(NDArray data, Shape size, bool keepRatio, int interp, NDArrayList @out = null)
        {
            return new Operator("_image_resize")
                .SetInput(data)
                .SetParam("size", size)
                .SetParam("keepRatio", keepRatio)
                .SetParam("interp", interp)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSoftmaxCrossEntropy(NDArrayList @out = null)
        {
            return new Operator("_backward_softmax_cross_entropy")
                .Invoke(@out);
        }

        public static NDArrayList _backwardActivation(NDArrayList @out = null)
        {
            return new Operator("_backward_Activation")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBatchNorm(NDArrayList @out = null)
        {
            return new Operator("_backward_BatchNorm")
                .Invoke(@out);
        }

        public static NDArrayList _backwardConcat(NDArrayList @out = null)
        {
            return new Operator("_backward_Concat")
                .Invoke(@out);
        }

        public static NDArrayList _rnnParamConcat(NDArrayList data, int numArgs, int dim, NDArrayList @out = null)
        {
            return new Operator("_rnn_param_concat")
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("dim", dim)
                .Invoke(@out);
        }

        public static NDArrayList _backwardConvolution(NDArrayList @out = null)
        {
            return new Operator("_backward_Convolution")
                .Invoke(@out);
        }

        public static NDArrayList _backwardCtcLoss(NDArrayList @out = null)
        {
            return new Operator("_backward_ctc_loss")
                .Invoke(@out);
        }

        public static NDArrayList _backwardDeconvolution(NDArrayList @out = null)
        {
            return new Operator("_backward_Deconvolution")
                .Invoke(@out);
        }

        public static NDArrayList _backwardDropout(NDArrayList @out = null)
        {
            return new Operator("_backward_Dropout")
                .Invoke(@out);
        }

        public static NDArrayList _backwardFullyConnected(NDArrayList @out = null)
        {
            return new Operator("_backward_FullyConnected")
                .Invoke(@out);
        }

        public static NDArrayList _backwardLayerNorm(NDArrayList @out = null)
        {
            return new Operator("_backward_LayerNorm")
                .Invoke(@out);
        }

        public static NDArrayList _backwardLRN(NDArrayList @out = null)
        {
            return new Operator("_backward_LRN")
                .Invoke(@out);
        }

        public static NDArrayList _backwardMoments(NDArrayList @out = null)
        {
            return new Operator("_backward_moments")
                .Invoke(@out);
        }

        public static NDArrayList _backwardPooling(NDArrayList @out = null)
        {
            return new Operator("_backward_Pooling")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSoftmax(NDArrayList args, NDArrayList @out = null)
        {
            return new Operator("_backward_softmax")
                .SetInput(args)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSoftmin(NDArrayList args, NDArrayList @out = null)
        {
            return new Operator("_backward_softmin")
                .SetInput(args)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLogSoftmax(NDArrayList args, NDArrayList @out = null)
        {
            return new Operator("_backward_log_softmax")
                .SetInput(args)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSoftmaxActivation(NDArrayList @out = null)
        {
            return new Operator("_backward_SoftmaxActivation")
                .Invoke(@out);
        }

        public static NDArrayList _backwardUpSampling(NDArrayList @out = null)
        {
            return new Operator("_backward_UpSampling")
                .Invoke(@out);
        }

        public static NDArrayList _sparseAdagradUpdate(NDArray weight, NDArray grad, NDArray history, float lr, float epsilon, float wd, float rescaleGrad, float clipGradient, NDArrayList @out = null)
        {
            return new Operator("_sparse_adagrad_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(history)
                .SetParam("lr", lr)
                .SetParam("epsilon", epsilon)
                .SetParam("wd", wd)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .Invoke(@out);
        }

        public static NDArrayList _contribDequantize(NDArray data, NDArray minRange, NDArray maxRange, string outType, NDArrayList @out = null)
        {
            return new Operator("_contrib_dequantize")
                .SetInput(data)
                .SetInput(minRange)
                .SetInput(maxRange)
                .SetParam("outType", outType)
                .Invoke(@out);
        }

        public static NDArrayList _contribQuantize(NDArray data, NDArray minRange, NDArray maxRange, string outType, NDArrayList @out = null)
        {
            return new Operator("_contrib_quantize")
                .SetInput(data)
                .SetInput(minRange)
                .SetInput(maxRange)
                .SetParam("outType", outType)
                .Invoke(@out);
        }

        public static NDArrayList _contribQuantizeV2(NDArray data, string outType, float minCalibRange, float maxCalibRange, NDArrayList @out = null)
        {
            return new Operator("_contrib_quantize_v2")
                .SetInput(data)
                .SetParam("outType", outType)
                .SetParam("minCalibRange", minCalibRange)
                .SetParam("maxCalibRange", maxCalibRange)
                .Invoke(@out);
        }

        public static NDArrayList _contribQuantizedAct(NDArray data, NDArray minData, NDArray maxData, string actType, NDArrayList @out = null)
        {
            return new Operator("_contrib_quantized_act")
                .SetInput(data)
                .SetInput(minData)
                .SetInput(maxData)
                .SetParam("actType", actType)
                .Invoke(@out);
        }

        public static NDArrayList _contribQuantizedConcat(NDArrayList data, int numArgs, int dim, NDArrayList @out = null)
        {
            return new Operator("_contrib_quantized_concat")
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("dim", dim)
                .Invoke(@out);
        }

        public static NDArrayList _contribQuantizedConv(NDArray data, NDArray weight, NDArray bias, NDArray minData, NDArray maxData, NDArray minWeight, NDArray maxWeight, NDArray minBias, NDArray maxBias, Shape kernel, Shape stride, Shape dilate, Shape pad, int numFilter, int numGroup, long workspace, bool noBias, string cudnnTune, bool cudnnOff, string layout, NDArrayList @out = null)
        {
            return new Operator("_contrib_quantized_conv")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetInput(minData)
                .SetInput(maxData)
                .SetInput(minWeight)
                .SetInput(maxWeight)
                .SetInput(minBias)
                .SetInput(maxBias)
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

        public static NDArrayList _contribQuantizedElemwiseAdd(NDArray lhs, NDArray rhs, NDArray lhsMin, NDArray lhsMax, NDArray rhsMin, NDArray rhsMax, NDArrayList @out = null)
        {
            return new Operator("_contrib_quantized_elemwise_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetInput(lhsMin)
                .SetInput(lhsMax)
                .SetInput(rhsMin)
                .SetInput(rhsMax)
                .Invoke(@out);
        }

        public static NDArrayList _contribQuantizedFlatten(NDArray data, NDArray minData, NDArray maxData, NDArrayList @out = null)
        {
            return new Operator("_contrib_quantized_flatten")
                .SetInput(data)
                .SetInput(minData)
                .SetInput(maxData)
                .Invoke(@out);
        }

        public static NDArrayList _contribQuantizedFullyConnected(NDArray data, NDArray weight, NDArray bias, NDArray minData, NDArray maxData, NDArray minWeight, NDArray maxWeight, NDArray minBias, NDArray maxBias, int numHidden, bool noBias, bool flatten, NDArrayList @out = null)
        {
            return new Operator("_contrib_quantized_fully_connected")
                .SetInput(data)
                .SetInput(weight)
                .SetInput(bias)
                .SetInput(minData)
                .SetInput(maxData)
                .SetInput(minWeight)
                .SetInput(maxWeight)
                .SetInput(minBias)
                .SetInput(maxBias)
                .SetParam("numHidden", numHidden)
                .SetParam("noBias", noBias)
                .SetParam("flatten", flatten)
                .Invoke(@out);
        }

        public static NDArrayList _contribQuantizedPooling(NDArray data, NDArray minData, NDArray maxData, Shape kernel, string poolType, bool globalPool, bool cudnnOff, string poolingConvention, Shape stride, Shape pad, int pValue, bool countIncludePad, string layout, NDArrayList @out = null)
        {
            return new Operator("_contrib_quantized_pooling")
                .SetInput(data)
                .SetInput(minData)
                .SetInput(maxData)
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

        public static NDArrayList _contribRequantize(NDArray data, NDArray minRange, NDArray maxRange, string outType, float minCalibRange, float maxCalibRange, NDArrayList @out = null)
        {
            return new Operator("_contrib_requantize")
                .SetInput(data)
                .SetInput(minRange)
                .SetInput(maxRange)
                .SetParam("outType", outType)
                .SetParam("minCalibRange", minCalibRange)
                .SetParam("maxCalibRange", maxCalibRange)
                .Invoke(@out);
        }

        public static NDArrayList _sampleUniform(NDArray low, Shape shape, string dtype, NDArray high, NDArrayList @out = null)
        {
            return new Operator("_sample_uniform")
                .SetInput(low)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(high)
                .Invoke(@out);
        }

        public static NDArrayList _sampleNormal(NDArray mu, Shape shape, string dtype, NDArray sigma, NDArrayList @out = null)
        {
            return new Operator("_sample_normal")
                .SetInput(mu)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(sigma)
                .Invoke(@out);
        }

        public static NDArrayList _sampleGamma(NDArray alpha, Shape shape, string dtype, NDArray beta, NDArrayList @out = null)
        {
            return new Operator("_sample_gamma")
                .SetInput(alpha)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(beta)
                .Invoke(@out);
        }

        public static NDArrayList _sampleExponential(NDArray lam, Shape shape, string dtype, NDArrayList @out = null)
        {
            return new Operator("_sample_exponential")
                .SetInput(lam)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _samplePoisson(NDArray lam, Shape shape, string dtype, NDArrayList @out = null)
        {
            return new Operator("_sample_poisson")
                .SetInput(lam)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _sampleNegativeBinomial(NDArray k, Shape shape, string dtype, NDArray p, NDArrayList @out = null)
        {
            return new Operator("_sample_negative_binomial")
                .SetInput(k)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(p)
                .Invoke(@out);
        }

        public static NDArrayList _sampleGeneralizedNegativeBinomial(NDArray mu, Shape shape, string dtype, NDArray alpha, NDArrayList @out = null)
        {
            return new Operator("_sample_generalized_negative_binomial")
                .SetInput(mu)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(alpha)
                .Invoke(@out);
        }

        public static NDArrayList _sampleMultinomial(NDArray data, Shape shape, bool getProb, string dtype, NDArrayList @out = null)
        {
            return new Operator("_sample_multinomial")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("getProb", getProb)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSampleMultinomial(NDArrayList @out = null)
        {
            return new Operator("_backward_sample_multinomial")
                .Invoke(@out);
        }

        public static NDArrayList _randomUniform(float low, float high, Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_random_uniform")
                .SetParam("low", low)
                .SetParam("high", high)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _randomNormal(float loc, float scale, Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_random_normal")
                .SetParam("loc", loc)
                .SetParam("scale", scale)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _randomGamma(float alpha, float beta, Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_random_gamma")
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _randomExponential(float lam, Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_random_exponential")
                .SetParam("lam", lam)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _randomPoisson(float lam, Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_random_poisson")
                .SetParam("lam", lam)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _randomNegativeBinomial(int k, float p, Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_random_negative_binomial")
                .SetParam("k", k)
                .SetParam("p", p)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _randomGeneralizedNegativeBinomial(float mu, float alpha, Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_random_generalized_negative_binomial")
                .SetParam("mu", mu)
                .SetParam("alpha", alpha)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _randomRandint(object low, object high, Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_random_randint")
                .SetParam("low", low)
                .SetParam("high", high)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _randomUniformLike(float low, float high, NDArray data, NDArrayList @out = null)
        {
            return new Operator("_random_uniform_like")
                .SetParam("low", low)
                .SetParam("high", high)
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _randomNormalLike(float loc, float scale, NDArray data, NDArrayList @out = null)
        {
            return new Operator("_random_normal_like")
                .SetParam("loc", loc)
                .SetParam("scale", scale)
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _randomGammaLike(float alpha, float beta, NDArray data, NDArrayList @out = null)
        {
            return new Operator("_random_gamma_like")
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _randomExponentialLike(float lam, NDArray data, NDArrayList @out = null)
        {
            return new Operator("_random_exponential_like")
                .SetParam("lam", lam)
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _randomPoissonLike(float lam, NDArray data, NDArrayList @out = null)
        {
            return new Operator("_random_poisson_like")
                .SetParam("lam", lam)
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _randomNegativeBinomialLike(int k, float p, NDArray data, NDArrayList @out = null)
        {
            return new Operator("_random_negative_binomial_like")
                .SetParam("k", k)
                .SetParam("p", p)
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _randomGeneralizedNegativeBinomialLike(float mu, float alpha, NDArray data, NDArrayList @out = null)
        {
            return new Operator("_random_generalized_negative_binomial_like")
                .SetParam("mu", mu)
                .SetParam("alpha", alpha)
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _shuffle(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_shuffle")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _sampleUniqueZipfian(int rangeMax, Shape shape, NDArrayList @out = null)
        {
            return new Operator("_sample_unique_zipfian")
                .SetParam("rangeMax", rangeMax)
                .SetParam("shape", shape)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinearRegOut(NDArrayList @out = null)
        {
            return new Operator("_backward_linear_reg_out")
                .Invoke(@out);
        }

        public static NDArrayList _backwardMaeRegOut(NDArrayList @out = null)
        {
            return new Operator("_backward_mae_reg_out")
                .Invoke(@out);
        }

        public static NDArrayList _backwardLogisticRegOut(NDArrayList @out = null)
        {
            return new Operator("_backward_logistic_reg_out")
                .Invoke(@out);
        }

        public static NDArrayList _backwardRNN(NDArrayList @out = null)
        {
            return new Operator("_backward_RNN")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSoftmaxOutput(NDArrayList @out = null)
        {
            return new Operator("_backward_SoftmaxOutput")
                .Invoke(@out);
        }

        public static NDArrayList _backwardAmpCast(NDArrayList @out = null)
        {
            return new Operator("_backward_amp_cast")
                .Invoke(@out);
        }

        public static NDArrayList _backwardAmpMulticast(NDArrayList grad, int numOutputs, NDArrayList @out = null)
        {
            return new Operator("_backward_amp_multicast")
                .SetInput(grad)
                .SetParam("numOutputs", numOutputs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardPick(NDArrayList @out = null)
        {
            return new Operator("_backward_pick")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSum(NDArrayList @out = null)
        {
            return new Operator("_backward_sum")
                .Invoke(@out);
        }

        public static NDArrayList _backwardMean(NDArrayList @out = null)
        {
            return new Operator("_backward_mean")
                .Invoke(@out);
        }

        public static NDArrayList _backwardProd(NDArrayList @out = null)
        {
            return new Operator("_backward_prod")
                .Invoke(@out);
        }

        public static NDArrayList _backwardNansum(NDArrayList @out = null)
        {
            return new Operator("_backward_nansum")
                .Invoke(@out);
        }

        public static NDArrayList _backwardNanprod(NDArrayList @out = null)
        {
            return new Operator("_backward_nanprod")
                .Invoke(@out);
        }

        public static NDArrayList _backwardMax(NDArrayList @out = null)
        {
            return new Operator("_backward_max")
                .Invoke(@out);
        }

        public static NDArrayList _backwardMin(NDArrayList @out = null)
        {
            return new Operator("_backward_min")
                .Invoke(@out);
        }

        public static NDArrayList _broadcastBackward(NDArrayList @out = null)
        {
            return new Operator("_broadcast_backward")
                .Invoke(@out);
        }

        public static NDArrayList _backwardNorm(NDArrayList @out = null)
        {
            return new Operator("_backward_norm")
                .Invoke(@out);
        }

        public static NDArrayList _backwardWhere(NDArrayList @out = null)
        {
            return new Operator("_backward_where")
                .Invoke(@out);
        }

        public static NDArrayList _backwardDiag(NDArrayList @out = null)
        {
            return new Operator("_backward_diag")
                .Invoke(@out);
        }

        public static NDArrayList _backwardDot(bool transposea, bool transposeb, string forwardStype, NDArrayList @out = null)
        {
            return new Operator("_backward_dot")
                .SetParam("transposea", transposea)
                .SetParam("transposeb", transposeb)
                .SetParam("forwardStype", forwardStype)
                .Invoke(@out);
        }

        public static NDArrayList _backwardBatchDot(NDArrayList @out = null)
        {
            return new Operator("_backward_batch_dot")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBroadcastAdd(NDArrayList @out = null)
        {
            return new Operator("_backward_broadcast_add")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBroadcastSub(NDArrayList @out = null)
        {
            return new Operator("_backward_broadcast_sub")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBroadcastMul(NDArrayList @out = null)
        {
            return new Operator("_backward_broadcast_mul")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBroadcastDiv(NDArrayList @out = null)
        {
            return new Operator("_backward_broadcast_div")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBroadcastMod(NDArrayList @out = null)
        {
            return new Operator("_backward_broadcast_mod")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBroadcastPower(NDArrayList @out = null)
        {
            return new Operator("_backward_broadcast_power")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBroadcastMaximum(NDArrayList @out = null)
        {
            return new Operator("_backward_broadcast_maximum")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBroadcastMinimum(NDArrayList @out = null)
        {
            return new Operator("_backward_broadcast_minimum")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBroadcastHypot(NDArrayList @out = null)
        {
            return new Operator("_backward_broadcast_hypot")
                .Invoke(@out);
        }

        public static NDArrayList _gradAdd(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_grad_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardAdd(NDArrayList @out = null)
        {
            return new Operator("_backward_add")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSub(NDArrayList @out = null)
        {
            return new Operator("_backward_sub")
                .Invoke(@out);
        }

        public static NDArrayList _backwardMul(NDArrayList @out = null)
        {
            return new Operator("_backward_mul")
                .Invoke(@out);
        }

        public static NDArrayList _backwardDiv(NDArrayList @out = null)
        {
            return new Operator("_backward_div")
                .Invoke(@out);
        }

        public static NDArrayList _mod(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_mod")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardMod(NDArrayList @out = null)
        {
            return new Operator("_backward_mod")
                .Invoke(@out);
        }

        public static NDArrayList _power(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_power")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardPower(NDArrayList @out = null)
        {
            return new Operator("_backward_power")
                .Invoke(@out);
        }

        public static NDArrayList _maximum(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_maximum")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardMaximum(NDArrayList @out = null)
        {
            return new Operator("_backward_maximum")
                .Invoke(@out);
        }

        public static NDArrayList _minimum(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_minimum")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardMinimum(NDArrayList @out = null)
        {
            return new Operator("_backward_minimum")
                .Invoke(@out);
        }

        public static NDArrayList _hypot(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_hypot")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardHypot(NDArrayList @out = null)
        {
            return new Operator("_backward_hypot")
                .Invoke(@out);
        }

        public static NDArrayList _equal(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _notEqual(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_not_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _greater(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_greater")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _greaterEqual(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_greater_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _lesser(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_lesser")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _lesserEqual(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_lesser_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _logicalAnd(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_logical_and")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _logicalOr(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_logical_or")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _logicalXor(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_logical_xor")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _plusScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_plus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _minusScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_minus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _rminusScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_rminus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _mulScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_mul_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardMulScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_mul_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _divScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_div_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardDivScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_div_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _rdivScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_rdiv_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardRdivScalar(NDArray lhs, NDArray rhs, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_rdiv_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _modScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_mod_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardModScalar(NDArray lhs, NDArray rhs, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_mod_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _rmodScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_rmod_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardRmodScalar(NDArray lhs, NDArray rhs, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_rmod_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _maximumScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_maximum_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardMaximumScalar(NDArray lhs, NDArray rhs, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_maximum_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _minimumScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_minimum_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardMinimumScalar(NDArray lhs, NDArray rhs, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_minimum_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _powerScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_power_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardPowerScalar(NDArray lhs, NDArray rhs, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_power_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _rpowerScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_rpower_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardRpowerScalar(NDArray lhs, NDArray rhs, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_rpower_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _hypotScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_hypot_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardHypotScalar(NDArray lhs, NDArray rhs, float scalar, NDArrayList @out = null)
        {
            return new Operator("_backward_hypot_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSmoothL1(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_smooth_l1")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _equalScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_equal_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _notEqualScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_not_equal_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _greaterScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_greater_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _greaterEqualScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_greater_equal_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _lesserScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_lesser_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _lesserEqualScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_lesser_equal_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _logicalAndScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_logical_and_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _logicalOrScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_logical_or_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _logicalXorScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_logical_xor_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _scatterElemwiseDiv(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_scatter_elemwise_div")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _scatterPlusScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_scatter_plus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _scatterMinusScalar(NDArray data, float scalar, NDArrayList @out = null)
        {
            return new Operator("_scatter_minus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .Invoke(@out);
        }

        public static NDArrayList _backwardRelu(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_relu")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSigmoid(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_sigmoid")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardHardSigmoid(NDArrayList @out = null)
        {
            return new Operator("_backward_hard_sigmoid")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSoftsign(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_softsign")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _copy(NDArray data, NDArrayList @out = null)
        {
            return new Operator("_copy")
                .SetInput(data)
                .Invoke(@out);
        }

        public static NDArrayList _backwardCopy(NDArrayList @out = null)
        {
            return new Operator("_backward_copy")
                .Invoke(@out);
        }

        public static NDArrayList _backwardReshape(NDArrayList @out = null)
        {
            return new Operator("_backward_reshape")
                .Invoke(@out);
        }

        public static NDArrayList _identityWithAttrLikeRhs(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_identity_with_attr_like_rhs")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardCast(NDArrayList @out = null)
        {
            return new Operator("_backward_cast")
                .Invoke(@out);
        }

        public static NDArrayList _backwardReciprocal(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_reciprocal")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardAbs(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_abs")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSign(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_sign")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSquare(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_square")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSqrt(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_sqrt")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardRsqrt(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_rsqrt")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardCbrt(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_cbrt")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardErf(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_erf")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardErfinv(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_erfinv")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardRcbrt(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_rcbrt")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLog(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_log")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLog10(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_log10")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLog2(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_log2")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLog1p(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_log1p")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardExpm1(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_expm1")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardGamma(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_gamma")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardGammaln(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_gammaln")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSin(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_sin")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardCos(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_cos")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardTan(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_tan")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardArcsin(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_arcsin")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardArccos(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_arccos")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardArctan(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_arctan")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardDegrees(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_degrees")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardRadians(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_radians")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSinh(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_sinh")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardCosh(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_cosh")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardTanh(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_tanh")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardArcsinh(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_arcsinh")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardArccosh(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_arccosh")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _backwardArctanh(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_backward_arctanh")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _histogram(NDArray data, NDArray bins, int binCnt, object range, NDArrayList @out = null)
        {
            return new Operator("_histogram")
                .SetInput(data)
                .SetInput(bins)
                .SetParam("binCnt", binCnt)
                .SetParam("range", range)
                .Invoke(@out);
        }

        public static NDArrayList _contribSparseEmbedding(NDArray data, NDArray weight, int inputDim, int outputDim, string dtype, bool sparseGrad, NDArrayList @out = null)
        {
            return new Operator("_contrib_SparseEmbedding")
                .SetInput(data)
                .SetInput(weight)
                .SetParam("inputDim", inputDim)
                .SetParam("outputDim", outputDim)
                .SetParam("dtype", dtype)
                .SetParam("sparseGrad", sparseGrad)
                .Invoke(@out);
        }

        public static NDArrayList _backwardEmbedding(NDArrayList @out = null)
        {
            return new Operator("_backward_Embedding")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSparseEmbedding(NDArrayList @out = null)
        {
            return new Operator("_backward_SparseEmbedding")
                .Invoke(@out);
        }

        public static NDArrayList _backwardTake(NDArrayList @out = null)
        {
            return new Operator("_backward_take")
                .Invoke(@out);
        }

        public static NDArrayList _backwardGatherNd(NDArray data, NDArray indices, Shape shape, NDArrayList @out = null)
        {
            return new Operator("_backward_gather_nd")
                .SetInput(data)
                .SetInput(indices)
                .SetParam("shape", shape)
                .Invoke(@out);
        }

        public static NDArrayList _scatterSetNd(NDArray lhs, NDArray rhs, NDArray indices, Shape shape, NDArrayList @out = null)
        {
            return new Operator("_scatter_set_nd")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetInput(indices)
                .SetParam("shape", shape)
                .Invoke(@out);
        }

        public static NDArrayList _zerosWithoutDtype(Shape shape, string ctx, int dtype, NDArrayList @out = null)
        {
            return new Operator("_zeros_without_dtype")
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _zeros(Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_zeros")
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _eye(object N, object M, object k, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_eye")
                .SetParam("N", N)
                .SetParam("M", M)
                .SetParam("k", k)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _ones(Shape shape, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_ones")
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _full(Shape shape, string ctx, string dtype, double value, NDArrayList @out = null)
        {
            return new Operator("_full")
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("value", value)
                .Invoke(@out);
        }

        public static NDArrayList _arange(double start, double stop, double step, int repeat, bool inferRange, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_arange")
                .SetParam("start", start)
                .SetParam("stop", stop)
                .SetParam("step", step)
                .SetParam("repeat", repeat)
                .SetParam("inferRange", inferRange)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _linspace(double start, double stop, double step, int repeat, bool inferRange, string ctx, string dtype, NDArrayList @out = null)
        {
            return new Operator("_linspace")
                .SetParam("start", start)
                .SetParam("stop", stop)
                .SetParam("step", step)
                .SetParam("repeat", repeat)
                .SetParam("inferRange", inferRange)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .Invoke(@out);
        }

        public static NDArrayList _linalgGemm(NDArray A, NDArray B, NDArray C, bool transposea, bool transposeb, double alpha, double beta, int axis, NDArrayList @out = null)
        {
            return new Operator("_linalg_gemm")
                .SetInput(A)
                .SetInput(B)
                .SetInput(C)
                .SetParam("transposea", transposea)
                .SetParam("transposeb", transposeb)
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgGemm(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_gemm")
                .Invoke(@out);
        }

        public static NDArrayList _linalgGemm2(NDArray A, NDArray B, bool transposea, bool transposeb, double alpha, int axis, NDArrayList @out = null)
        {
            return new Operator("_linalg_gemm2")
                .SetInput(A)
                .SetInput(B)
                .SetParam("transposea", transposea)
                .SetParam("transposeb", transposeb)
                .SetParam("alpha", alpha)
                .SetParam("axis", axis)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgGemm2(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_gemm2")
                .Invoke(@out);
        }

        public static NDArrayList _linalgPotrf(NDArray A, NDArrayList @out = null)
        {
            return new Operator("_linalg_potrf")
                .SetInput(A)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgPotrf(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_potrf")
                .Invoke(@out);
        }

        public static NDArrayList _linalgPotri(NDArray A, NDArrayList @out = null)
        {
            return new Operator("_linalg_potri")
                .SetInput(A)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgPotri(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_potri")
                .Invoke(@out);
        }

        public static NDArrayList _linalgTrmm(NDArray A, NDArray B, bool transpose, bool rightside, bool lower, double alpha, NDArrayList @out = null)
        {
            return new Operator("_linalg_trmm")
                .SetInput(A)
                .SetInput(B)
                .SetParam("transpose", transpose)
                .SetParam("rightside", rightside)
                .SetParam("lower", lower)
                .SetParam("alpha", alpha)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgTrmm(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_trmm")
                .Invoke(@out);
        }

        public static NDArrayList _linalgTrsm(NDArray A, NDArray B, bool transpose, bool rightside, bool lower, double alpha, NDArrayList @out = null)
        {
            return new Operator("_linalg_trsm")
                .SetInput(A)
                .SetInput(B)
                .SetParam("transpose", transpose)
                .SetParam("rightside", rightside)
                .SetParam("lower", lower)
                .SetParam("alpha", alpha)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgTrsm(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_trsm")
                .Invoke(@out);
        }

        public static NDArrayList _linalgSumlogdiag(NDArray A, NDArrayList @out = null)
        {
            return new Operator("_linalg_sumlogdiag")
                .SetInput(A)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgSumlogdiag(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_sumlogdiag")
                .Invoke(@out);
        }

        public static NDArrayList _linalgExtractdiag(NDArray A, int offset, NDArrayList @out = null)
        {
            return new Operator("_linalg_extractdiag")
                .SetInput(A)
                .SetParam("offset", offset)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgExtractdiag(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_extractdiag")
                .Invoke(@out);
        }

        public static NDArrayList _linalgMakediag(NDArray A, int offset, NDArrayList @out = null)
        {
            return new Operator("_linalg_makediag")
                .SetInput(A)
                .SetParam("offset", offset)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgMakediag(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_makediag")
                .Invoke(@out);
        }

        public static NDArrayList _linalgExtracttrian(NDArray A, int offset, bool lower, NDArrayList @out = null)
        {
            return new Operator("_linalg_extracttrian")
                .SetInput(A)
                .SetParam("offset", offset)
                .SetParam("lower", lower)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgExtracttrian(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_extracttrian")
                .Invoke(@out);
        }

        public static NDArrayList _linalgMaketrian(NDArray A, int offset, bool lower, NDArrayList @out = null)
        {
            return new Operator("_linalg_maketrian")
                .SetInput(A)
                .SetParam("offset", offset)
                .SetParam("lower", lower)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgMaketrian(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_maketrian")
                .Invoke(@out);
        }

        public static NDArrayList _linalgSyrk(NDArray A, bool transpose, double alpha, NDArrayList @out = null)
        {
            return new Operator("_linalg_syrk")
                .SetInput(A)
                .SetParam("transpose", transpose)
                .SetParam("alpha", alpha)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgSyrk(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_syrk")
                .Invoke(@out);
        }

        public static NDArrayList _linalgGelqf(NDArray A, NDArrayList @out = null)
        {
            return new Operator("_linalg_gelqf")
                .SetInput(A)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgGelqf(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_gelqf")
                .Invoke(@out);
        }

        public static NDArrayList _linalgSyevd(NDArray A, NDArrayList @out = null)
        {
            return new Operator("_linalg_syevd")
                .SetInput(A)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgSyevd(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_syevd")
                .Invoke(@out);
        }

        public static NDArrayList _linalgInverse(NDArray A, NDArrayList @out = null)
        {
            return new Operator("_linalg_inverse")
                .SetInput(A)
                .Invoke(@out);
        }

        public static NDArrayList _backwardLinalgInverse(NDArrayList @out = null)
        {
            return new Operator("_backward_linalg_inverse")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSlice(NDArrayList @out = null)
        {
            return new Operator("_backward_slice")
                .Invoke(@out);
        }

        public static NDArrayList _sliceAssign(NDArray lhs, NDArray rhs, Shape begin, Shape end, Shape step, NDArrayList @out = null)
        {
            return new Operator("_slice_assign")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetParam("step", step)
                .Invoke(@out);
        }

        public static NDArrayList _sliceAssignScalar(NDArray data, double scalar, Shape begin, Shape end, Shape step, NDArrayList @out = null)
        {
            return new Operator("_slice_assign_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetParam("step", step)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSliceAxis(NDArrayList @out = null)
        {
            return new Operator("_backward_slice_axis")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSliceLike(NDArrayList @out = null)
        {
            return new Operator("_backward_slice_like")
                .Invoke(@out);
        }

        public static NDArrayList _backwardClip(NDArrayList @out = null)
        {
            return new Operator("_backward_clip")
                .Invoke(@out);
        }

        public static NDArrayList _backwardRepeat(NDArrayList @out = null)
        {
            return new Operator("_backward_repeat")
                .Invoke(@out);
        }

        public static NDArrayList _backwardTile(NDArrayList @out = null)
        {
            return new Operator("_backward_tile")
                .Invoke(@out);
        }

        public static NDArrayList _backwardReverse(NDArrayList @out = null)
        {
            return new Operator("_backward_reverse")
                .Invoke(@out);
        }

        public static NDArrayList _backwardStack(NDArrayList @out = null)
        {
            return new Operator("_backward_stack")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSqueeze(NDArrayList @out = null)
        {
            return new Operator("_backward_squeeze")
                .Invoke(@out);
        }

        public static NDArrayList _splitV2(NDArray data, Shape indices, int axis, bool squeezeAxis, int sections, NDArrayList @out = null)
        {
            return new Operator("_split_v2")
                .SetInput(data)
                .SetParam("indices", indices)
                .SetParam("axis", axis)
                .SetParam("squeezeAxis", squeezeAxis)
                .SetParam("sections", sections)
                .Invoke(@out);
        }

        public static NDArrayList _splitV2Backward(NDArrayList @out = null)
        {
            return new Operator("_split_v2_backward")
                .Invoke(@out);
        }

        public static NDArrayList _backwardTopk(NDArrayList @out = null)
        {
            return new Operator("_backward_topk")
                .Invoke(@out);
        }

        public static NDArrayList _ravelMultiIndex(NDArray data, Shape shape, NDArrayList @out = null)
        {
            return new Operator("_ravel_multi_index")
                .SetInput(data)
                .SetParam("shape", shape)
                .Invoke(@out);
        }

        public static NDArrayList _unravelIndex(NDArray data, Shape shape, NDArrayList @out = null)
        {
            return new Operator("_unravel_index")
                .SetInput(data)
                .SetParam("shape", shape)
                .Invoke(@out);
        }

        public static NDArrayList _sparseRetain(NDArray data, NDArray indices, NDArrayList @out = null)
        {
            return new Operator("_sparse_retain")
                .SetInput(data)
                .SetInput(indices)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSparseRetain(NDArrayList @out = null)
        {
            return new Operator("_backward_sparse_retain")
                .Invoke(@out);
        }

        public static NDArrayList _squareSum(NDArray data, Shape axis, bool keepdims, bool exclude, NDArrayList @out = null)
        {
            return new Operator("_square_sum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .Invoke(@out);
        }

        public static NDArrayList _backwardSquareSum(NDArrayList @out = null)
        {
            return new Operator("_backward_square_sum")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBatchNormV1(NDArrayList @out = null)
        {
            return new Operator("_backward_BatchNorm_v1")
                .Invoke(@out);
        }

        public static NDArrayList _backwardBilinearSampler(NDArrayList @out = null)
        {
            return new Operator("_backward_BilinearSampler")
                .Invoke(@out);
        }

        public static NDArrayList _contribCountSketch(NDArray data, NDArray h, NDArray s, int outDim, int processingBatchSize, NDArrayList @out = null)
        {
            return new Operator("_contrib_count_sketch")
                .SetInput(data)
                .SetInput(h)
                .SetInput(s)
                .SetParam("outDim", outDim)
                .SetParam("processingBatchSize", processingBatchSize)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribCountSketch(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_count_sketch")
                .Invoke(@out);
        }

        public static NDArrayList _contribDeformableConvolution(NDArray data, NDArray offset, NDArray weight, NDArray bias, Shape kernel, Shape stride, Shape dilate, Shape pad, int numFilter, int numGroup, int numDeformableGroup, long workspace, bool noBias, string layout, NDArrayList @out = null)
        {
            return new Operator("_contrib_DeformableConvolution")
                .SetInput(data)
                .SetInput(offset)
                .SetInput(weight)
                .SetInput(bias)
                .SetParam("kernel", kernel)
                .SetParam("stride", stride)
                .SetParam("dilate", dilate)
                .SetParam("pad", pad)
                .SetParam("numFilter", numFilter)
                .SetParam("numGroup", numGroup)
                .SetParam("numDeformableGroup", numDeformableGroup)
                .SetParam("workspace", workspace)
                .SetParam("noBias", noBias)
                .SetParam("layout", layout)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribDeformableConvolution(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_DeformableConvolution")
                .Invoke(@out);
        }

        public static NDArrayList _contribDeformablePSROIPooling(Symbol data, Symbol rois, Symbol trans, float spatialScale, int outputDim, int groupSize, int pooledSize, int partSize, int samplePerPart, float transStd, bool noTrans, NDArrayList @out = null)
        {
            return new Operator("_contrib_DeformablePSROIPooling")
                .SetInput(data)
                .SetInput(rois)
                .SetInput(trans)
                .SetParam("spatialScale", spatialScale)
                .SetParam("outputDim", outputDim)
                .SetParam("groupSize", groupSize)
                .SetParam("pooledSize", pooledSize)
                .SetParam("partSize", partSize)
                .SetParam("samplePerPart", samplePerPart)
                .SetParam("transStd", transStd)
                .SetParam("noTrans", noTrans)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribDeformablePSROIPooling(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_DeformablePSROIPooling")
                .Invoke(@out);
        }

        public static NDArrayList _contribFft(NDArray data, int computeSize, NDArrayList @out = null)
        {
            return new Operator("_contrib_fft")
                .SetInput(data)
                .SetParam("computeSize", computeSize)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribFft(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_fft")
                .Invoke(@out);
        }

        public static NDArrayList _contribIfft(NDArray data, int computeSize, NDArrayList @out = null)
        {
            return new Operator("_contrib_ifft")
                .SetInput(data)
                .SetParam("computeSize", computeSize)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribIfft(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_ifft")
                .Invoke(@out);
        }

        public static NDArrayList _contribMultiProposal(NDArray clsProb, NDArray bboxPred, NDArray imInfo, int rpnPreNmsTopn, int rpnPostNmsTopn, float threshold, int rpnMinSize, object scales, object ratios, int featureStride, bool outputScore, bool iouLoss, NDArrayList @out = null)
        {
            return new Operator("_contrib_MultiProposal")
                .SetInput(clsProb)
                .SetInput(bboxPred)
                .SetInput(imInfo)
                .SetParam("rpnPreNmsTopn", rpnPreNmsTopn)
                .SetParam("rpnPostNmsTopn", rpnPostNmsTopn)
                .SetParam("threshold", threshold)
                .SetParam("rpnMinSize", rpnMinSize)
                .SetParam("scales", scales)
                .SetParam("ratios", ratios)
                .SetParam("featureStride", featureStride)
                .SetParam("outputScore", outputScore)
                .SetParam("iouLoss", iouLoss)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribMultiProposal(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_MultiProposal")
                .Invoke(@out);
        }

        public static NDArrayList _contribMultiBoxDetection(NDArray clsProb, NDArray locPred, NDArray anchor, bool clip, float threshold, int backgroundId, float nmsThreshold, bool forceSuppress, object variances, int nmsTopk, NDArrayList @out = null)
        {
            return new Operator("_contrib_MultiBoxDetection")
                .SetInput(clsProb)
                .SetInput(locPred)
                .SetInput(anchor)
                .SetParam("clip", clip)
                .SetParam("threshold", threshold)
                .SetParam("backgroundId", backgroundId)
                .SetParam("nmsThreshold", nmsThreshold)
                .SetParam("forceSuppress", forceSuppress)
                .SetParam("variances", variances)
                .SetParam("nmsTopk", nmsTopk)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribMultiBoxDetection(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_MultiBoxDetection")
                .Invoke(@out);
        }

        public static NDArrayList _contribMultiBoxPrior(NDArray data, object sizes, object ratios, bool clip, object steps, object offsets, NDArrayList @out = null)
        {
            return new Operator("_contrib_MultiBoxPrior")
                .SetInput(data)
                .SetParam("sizes", sizes)
                .SetParam("ratios", ratios)
                .SetParam("clip", clip)
                .SetParam("steps", steps)
                .SetParam("offsets", offsets)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribMultiBoxPrior(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_MultiBoxPrior")
                .Invoke(@out);
        }

        public static NDArrayList _contribMultiBoxTarget(NDArray anchor, NDArray label, NDArray clsPred, float overlapThreshold, float ignoreLabel, float negativeMiningRatio, float negativeMiningThresh, int minimumNegativeSamples, object variances, NDArrayList @out = null)
        {
            return new Operator("_contrib_MultiBoxTarget")
                .SetInput(anchor)
                .SetInput(label)
                .SetInput(clsPred)
                .SetParam("overlapThreshold", overlapThreshold)
                .SetParam("ignoreLabel", ignoreLabel)
                .SetParam("negativeMiningRatio", negativeMiningRatio)
                .SetParam("negativeMiningThresh", negativeMiningThresh)
                .SetParam("minimumNegativeSamples", minimumNegativeSamples)
                .SetParam("variances", variances)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribMultiBoxTarget(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_MultiBoxTarget")
                .Invoke(@out);
        }

        public static NDArrayList _contribProposal(NDArray clsProb, NDArray bboxPred, NDArray imInfo, int rpnPreNmsTopn, int rpnPostNmsTopn, float threshold, int rpnMinSize, object scales, object ratios, int featureStride, bool outputScore, bool iouLoss, NDArrayList @out = null)
        {
            return new Operator("_contrib_Proposal")
                .SetInput(clsProb)
                .SetInput(bboxPred)
                .SetInput(imInfo)
                .SetParam("rpnPreNmsTopn", rpnPreNmsTopn)
                .SetParam("rpnPostNmsTopn", rpnPostNmsTopn)
                .SetParam("threshold", threshold)
                .SetParam("rpnMinSize", rpnMinSize)
                .SetParam("scales", scales)
                .SetParam("ratios", ratios)
                .SetParam("featureStride", featureStride)
                .SetParam("outputScore", outputScore)
                .SetParam("iouLoss", iouLoss)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribProposal(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_Proposal")
                .Invoke(@out);
        }

        public static NDArrayList _contribPSROIPooling(Symbol data, Symbol rois, float spatialScale, int outputDim, int pooledSize, int groupSize, NDArrayList @out = null)
        {
            return new Operator("_contrib_PSROIPooling")
                .SetInput(data)
                .SetInput(rois)
                .SetParam("spatialScale", spatialScale)
                .SetParam("outputDim", outputDim)
                .SetParam("pooledSize", pooledSize)
                .SetParam("groupSize", groupSize)
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribPSROIPooling(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_PSROIPooling")
                .Invoke(@out);
        }

        public static NDArrayList _backwardContribSyncBatchNorm(NDArrayList @out = null)
        {
            return new Operator("_backward__contrib_SyncBatchNorm")
                .Invoke(@out);
        }

        public static NDArrayList _backwardConvolutionV1(NDArrayList @out = null)
        {
            return new Operator("_backward_Convolution_v1")
                .Invoke(@out);
        }

        public static NDArrayList _backwardCorrelation(NDArrayList @out = null)
        {
            return new Operator("_backward_Correlation")
                .Invoke(@out);
        }

        public static NDArrayList _backwardCrop(NDArrayList @out = null)
        {
            return new Operator("_backward_Crop")
                .Invoke(@out);
        }

        public static NDArrayList _CrossDeviceCopy(NDArrayList @out = null)
        {
            return new Operator("_CrossDeviceCopy")
                .Invoke(@out);
        }

        public static NDArrayList _backwardCrossDeviceCopy(NDArrayList @out = null)
        {
            return new Operator("_backward__CrossDeviceCopy")
                .Invoke(@out);
        }

        public static NDArrayList _Native(NDArrayList data, IntPtr info, bool needTopGrad, NDArrayList @out = null)
        {
            return new Operator("_Native")
                .SetInput(data)
                .SetParam("info", info)
                .SetParam("needTopGrad", needTopGrad)
                .Invoke(@out);
        }

        public static NDArrayList _backwardNative(NDArrayList @out = null)
        {
            return new Operator("_backward__Native")
                .Invoke(@out);
        }

        public static NDArrayList _NDArray(NDArrayList data, IntPtr info, NDArrayList @out = null)
        {
            return new Operator("_NDArray")
                .SetInput(data)
                .SetParam("info", info)
                .Invoke(@out);
        }

        public static NDArrayList _backwardNDArray(NDArrayList @out = null)
        {
            return new Operator("_backward__NDArray")
                .Invoke(@out);
        }

        public static NDArrayList _backwardGridGenerator(NDArrayList @out = null)
        {
            return new Operator("_backward_GridGenerator")
                .Invoke(@out);
        }

        public static NDArrayList _backwardIdentityAttachKLSparseReg(NDArrayList @out = null)
        {
            return new Operator("_backward_IdentityAttachKLSparseReg")
                .Invoke(@out);
        }

        public static NDArrayList _backwardInstanceNorm(NDArrayList @out = null)
        {
            return new Operator("_backward_InstanceNorm")
                .Invoke(@out);
        }

        public static NDArrayList _backwardL2Normalization(NDArrayList @out = null)
        {
            return new Operator("_backward_L2Normalization")
                .Invoke(@out);
        }

        public static NDArrayList _backwardLeakyReLU(NDArrayList @out = null)
        {
            return new Operator("_backward_LeakyReLU")
                .Invoke(@out);
        }

        public static NDArrayList _backwardMakeLoss(NDArrayList @out = null)
        {
            return new Operator("_backward_MakeLoss")
                .Invoke(@out);
        }

        public static NDArrayList _backwardPad(NDArrayList @out = null)
        {
            return new Operator("_backward_Pad")
                .Invoke(@out);
        }

        public static NDArrayList _backwardPoolingV1(NDArrayList @out = null)
        {
            return new Operator("_backward_Pooling_v1")
                .Invoke(@out);
        }

        public static NDArrayList _backwardROIPooling(NDArrayList @out = null)
        {
            return new Operator("_backward_ROIPooling")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSequenceLast(NDArrayList @out = null)
        {
            return new Operator("_backward_SequenceLast")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSequenceMask(NDArrayList @out = null)
        {
            return new Operator("_backward_SequenceMask")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSequenceReverse(NDArrayList @out = null)
        {
            return new Operator("_backward_SequenceReverse")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSliceChannel(NDArrayList @out = null)
        {
            return new Operator("_backward_SliceChannel")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSpatialTransformer(NDArrayList @out = null)
        {
            return new Operator("_backward_SpatialTransformer")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSVMOutput(NDArrayList @out = null)
        {
            return new Operator("_backward_SVMOutput")
                .Invoke(@out);
        }

        public static NDArrayList _backwardSwapAxis(NDArrayList @out = null)
        {
            return new Operator("_backward_SwapAxis")
                .Invoke(@out);
        }

        public static NDArrayList _setValue(float src, NDArrayList @out = null)
        {
            return new Operator("_set_value")
                .SetParam("src", src)
                .Invoke(@out);
        }

        public static NDArrayList _onehotEncode(NDArray lhs, NDArray rhs, NDArrayList @out = null)
        {
            return new Operator("_onehot_encode")
                .SetInput(lhs)
                .SetInput(rhs)
                .Invoke(@out);
        }

        public static NDArrayList _imdecode(NDArray mean, int index, int x0, int y0, int x1, int y1, int c, int size, NDArrayList @out = null)
        {
            return new Operator("_imdecode")
                .SetInput(mean)
                .SetParam("index", index)
                .SetParam("x0", x0)
                .SetParam("y0", y0)
                .SetParam("x1", x1)
                .SetParam("y1", y1)
                .SetParam("c", c)
                .SetParam("size", size)
                .Invoke(@out);
        }

        }
    }
}
