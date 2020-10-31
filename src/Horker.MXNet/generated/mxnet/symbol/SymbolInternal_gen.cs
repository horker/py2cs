using System;
using Horker.MXNet;
using Horker.MXNet.Interop;

namespace Horker.MXNet
{
    public partial class Symbol : SymbolBase
    {
        public static class _internal
        {
        public static SymbolList _CustomFunction(string symbol_name = null)
        {
            return new Operator("_CustomFunction")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCustomFunction(string symbol_name = null)
        {
            return new Operator("_backward_CustomFunction")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _CachedOp(SymbolList data, string symbol_name = null)
        {
            return new Operator("_CachedOp")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCachedOp(string symbol_name = null)
        {
            return new Operator("_backward_CachedOp")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _cvimdecode(NDArray buf, int flag, bool toRgb, string symbol_name = null)
        {
            return new Operator("_cvimdecode")
                .SetInput(buf)
                .SetParam("flag", flag)
                .SetParam("toRgb", toRgb)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _cvimread(string filename, int flag, bool toRgb, string symbol_name = null)
        {
            return new Operator("_cvimread")
                .SetParam("filename", filename)
                .SetParam("flag", flag)
                .SetParam("toRgb", toRgb)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _cvimresize(NDArray src, int w, int h, int interp, string symbol_name = null)
        {
            return new Operator("_cvimresize")
                .SetInput(src)
                .SetParam("w", w)
                .SetParam("h", h)
                .SetParam("interp", interp)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _cvcopyMakeBorder(NDArray src, int top, int bot, int left, int right, int type, double value, object values, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _copyto(NDArray data, string symbol_name = null)
        {
            return new Operator("_copyto")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _NoGradient(string symbol_name = null)
        {
            return new Operator("_NoGradient")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _mpAdamwUpdate(Symbol weight, Symbol grad, Symbol mean, Symbol var, Symbol weight32, Symbol rescaleGrad, float lr, float beta1, float beta2, float epsilon, float wd, float eta, float clipGradient, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _adamwUpdate(Symbol weight, Symbol grad, Symbol mean, Symbol var, Symbol rescaleGrad, float lr, float beta1, float beta2, float epsilon, float wd, float eta, float clipGradient, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribAdaptiveAvgPooling2D(Symbol data, Shape outputSize, string symbol_name = null)
        {
            return new Operator("_contrib_AdaptiveAvgPooling2D")
                .SetInput(data)
                .SetParam("outputSize", outputSize)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribAdaptiveAvgPooling2D(string symbol_name = null)
        {
            return new Operator("_backward_contrib_AdaptiveAvgPooling2D")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribBilinearResize2D(Symbol data, Symbol like, int height, int width, float scaleHeight, float scaleWidth, string mode, string symbol_name = null)
        {
            return new Operator("_contrib_BilinearResize2D")
                .SetInput(data)
                .SetInput(like)
                .SetParam("height", height)
                .SetParam("width", width)
                .SetParam("scaleHeight", scaleHeight)
                .SetParam("scaleWidth", scaleWidth)
                .SetParam("mode", mode)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribBilinearResize2D(string symbol_name = null)
        {
            return new Operator("_backward_contrib_BilinearResize2D")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribBooleanMask(Symbol data, Symbol index, int axis, string symbol_name = null)
        {
            return new Operator("_contrib_boolean_mask")
                .SetInput(data)
                .SetInput(index)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribBooleanMask(int axis, string symbol_name = null)
        {
            return new Operator("_backward_contrib_boolean_mask")
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribBoxNms(Symbol data, float overlapThresh, float validThresh, int topk, int coordStart, int scoreIndex, int idIndex, int backgroundId, bool forceSuppress, string inFormat, string outFormat, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribBoxNms(float overlapThresh, float validThresh, int topk, int coordStart, int scoreIndex, int idIndex, int backgroundId, bool forceSuppress, string inFormat, string outFormat, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribBoxIou(Symbol lhs, Symbol rhs, string format, string symbol_name = null)
        {
            return new Operator("_contrib_box_iou")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("format", format)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribBoxIou(string format, string symbol_name = null)
        {
            return new Operator("_backward_contrib_box_iou")
                .SetParam("format", format)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribBipartiteMatching(Symbol data, bool isAscend, float threshold, int topk, string symbol_name = null)
        {
            return new Operator("_contrib_bipartite_matching")
                .SetInput(data)
                .SetParam("isAscend", isAscend)
                .SetParam("threshold", threshold)
                .SetParam("topk", topk)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribBipartiteMatching(bool isAscend, float threshold, int topk, string symbol_name = null)
        {
            return new Operator("_backward_contrib_bipartite_matching")
                .SetParam("isAscend", isAscend)
                .SetParam("threshold", threshold)
                .SetParam("topk", topk)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribDglCsrNeighborUniformSample(Symbol csrMatrix, SymbolList seedArrays, int numArgs, object numHops, object numNeighbor, object maxNumVertices, string symbol_name = null)
        {
            return new Operator("_contrib_dgl_csr_neighbor_uniform_sample")
                .SetInput(csrMatrix)
                .SetInput(seedArrays)
                .SetParam("numArgs", numArgs)
                .SetParam("numHops", numHops)
                .SetParam("numNeighbor", numNeighbor)
                .SetParam("maxNumVertices", maxNumVertices)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribDglCsrNeighborNonUniformSample(Symbol csrMatrix, Symbol probability, SymbolList seedArrays, int numArgs, object numHops, object numNeighbor, object maxNumVertices, string symbol_name = null)
        {
            return new Operator("_contrib_dgl_csr_neighbor_non_uniform_sample")
                .SetInput(csrMatrix)
                .SetInput(probability)
                .SetInput(seedArrays)
                .SetParam("numArgs", numArgs)
                .SetParam("numHops", numHops)
                .SetParam("numNeighbor", numNeighbor)
                .SetParam("maxNumVertices", maxNumVertices)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribDglSubgraph(Symbol graph, SymbolList data, int numArgs, bool returnMapping, string symbol_name = null)
        {
            return new Operator("_contrib_dgl_subgraph")
                .SetInput(graph)
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("returnMapping", returnMapping)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribEdgeId(Symbol data, Symbol u, Symbol v, string symbol_name = null)
        {
            return new Operator("_contrib_edge_id")
                .SetInput(data)
                .SetInput(u)
                .SetInput(v)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribDglAdjacency(Symbol data, string symbol_name = null)
        {
            return new Operator("_contrib_dgl_adjacency")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribDglGraphCompact(SymbolList graphData, int numArgs, bool returnMapping, object graphSizes, string symbol_name = null)
        {
            return new Operator("_contrib_dgl_graph_compact")
                .SetInput(graphData)
                .SetParam("numArgs", numArgs)
                .SetParam("returnMapping", returnMapping)
                .SetParam("graphSizes", graphSizes)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribGradientmultiplier(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_contrib_gradientmultiplier")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribBackwardGradientmultiplier(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_contrib_backward_gradientmultiplier")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribHawkesll(Symbol lda, Symbol alpha, Symbol beta, Symbol state, Symbol lags, Symbol marks, Symbol validLength, Symbol maxTime, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribBackwardHawkesll(string symbol_name = null)
        {
            return new Operator("_contrib_backward_hawkesll")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribIndexArray(Symbol data, Shape axes, string symbol_name = null)
        {
            return new Operator("_contrib_index_array")
                .SetInput(data)
                .SetParam("axes", axes)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribIndexCopy(Symbol oldTensor, Symbol indexVector, Symbol newTensor, string symbol_name = null)
        {
            return new Operator("_contrib_index_copy")
                .SetInput(oldTensor)
                .SetInput(indexVector)
                .SetInput(newTensor)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribBackwardIndexCopy(string symbol_name = null)
        {
            return new Operator("_contrib_backward_index_copy")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribGetnnz(Symbol data, int axis, string symbol_name = null)
        {
            return new Operator("_contrib_getnnz")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribGroupAdagradUpdate(Symbol weight, Symbol grad, Symbol history, float lr, float rescaleGrad, float clipGradient, float epsilon, string symbol_name = null)
        {
            return new Operator("_contrib_group_adagrad_update")
                .SetInput(weight)
                .SetInput(grad)
                .SetInput(history)
                .SetParam("lr", lr)
                .SetParam("rescaleGrad", rescaleGrad)
                .SetParam("clipGradient", clipGradient)
                .SetParam("epsilon", epsilon)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuadratic(Symbol data, float a, float b, float c, string symbol_name = null)
        {
            return new Operator("_contrib_quadratic")
                .SetInput(data)
                .SetParam("a", a)
                .SetParam("b", b)
                .SetParam("c", c)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribBackwardQuadratic(string symbol_name = null)
        {
            return new Operator("_contrib_backward_quadratic")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribROIAlign(Symbol data, Symbol rois, Shape pooledSize, float spatialScale, int sampleRatio, bool positionSensitive, string symbol_name = null)
        {
            return new Operator("_contrib_ROIAlign")
                .SetInput(data)
                .SetInput(rois)
                .SetParam("pooledSize", pooledSize)
                .SetParam("spatialScale", spatialScale)
                .SetParam("sampleRatio", sampleRatio)
                .SetParam("positionSensitive", positionSensitive)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardROIAlign(string symbol_name = null)
        {
            return new Operator("_backward_ROIAlign")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribSyncBatchNorm(Symbol data, Symbol gamma, Symbol beta, Symbol movingMean, Symbol movingVar, float eps, float momentum, bool fixGamma, bool useGlobalStats, bool outputMeanVar, int ndev, string key, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribDivSqrtDim(Symbol data, string symbol_name = null)
        {
            return new Operator("_contrib_div_sqrt_dim")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _foreach(Symbol fn, SymbolList data, int numArgs, int numOutputs, int numOutData, object inStateLocs, object inDataLocs, object remainLocs, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardForeach(string symbol_name = null)
        {
            return new Operator("_backward_foreach")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _whileLoop(Symbol cond, Symbol func, SymbolList data, int numArgs, int numOutputs, int numOutData, int maxIterations, object condInputLocs, object funcInputLocs, object funcVarLocs, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardWhileLoop(string symbol_name = null)
        {
            return new Operator("_backward_while_loop")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _cond(Symbol cond, Symbol thenBranch, Symbol elseBranch, SymbolList data, int numArgs, int numOutputs, object condInputLocs, object thenInputLocs, object elseInputLocs, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCond(string symbol_name = null)
        {
            return new Operator("_backward_cond")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCustom(string symbol_name = null)
        {
            return new Operator("_backward_Custom")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageCrop(Symbol data, int x, int y, int width, int height, string symbol_name = null)
        {
            return new Operator("_image_crop")
                .SetInput(data)
                .SetParam("x", x)
                .SetParam("y", y)
                .SetParam("width", width)
                .SetParam("height", height)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardImageCrop(string symbol_name = null)
        {
            return new Operator("_backward_image_crop")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageToTensor(Symbol data, string symbol_name = null)
        {
            return new Operator("_image_to_tensor")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageNormalize(Symbol data, object mean, object std, string symbol_name = null)
        {
            return new Operator("_image_normalize")
                .SetInput(data)
                .SetParam("mean", mean)
                .SetParam("std", std)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardImageNormalize(string symbol_name = null)
        {
            return new Operator("_backward_image_normalize")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageFlipLeftRight(Symbol data, string symbol_name = null)
        {
            return new Operator("_image_flip_left_right")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageRandomFlipLeftRight(Symbol data, string symbol_name = null)
        {
            return new Operator("_image_random_flip_left_right")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageFlipTopBottom(Symbol data, string symbol_name = null)
        {
            return new Operator("_image_flip_top_bottom")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageRandomFlipTopBottom(Symbol data, string symbol_name = null)
        {
            return new Operator("_image_random_flip_top_bottom")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageRandomBrightness(Symbol data, float minFactor, float maxFactor, string symbol_name = null)
        {
            return new Operator("_image_random_brightness")
                .SetInput(data)
                .SetParam("minFactor", minFactor)
                .SetParam("maxFactor", maxFactor)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageRandomContrast(Symbol data, float minFactor, float maxFactor, string symbol_name = null)
        {
            return new Operator("_image_random_contrast")
                .SetInput(data)
                .SetParam("minFactor", minFactor)
                .SetParam("maxFactor", maxFactor)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageRandomSaturation(Symbol data, float minFactor, float maxFactor, string symbol_name = null)
        {
            return new Operator("_image_random_saturation")
                .SetInput(data)
                .SetParam("minFactor", minFactor)
                .SetParam("maxFactor", maxFactor)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageRandomHue(Symbol data, float minFactor, float maxFactor, string symbol_name = null)
        {
            return new Operator("_image_random_hue")
                .SetInput(data)
                .SetParam("minFactor", minFactor)
                .SetParam("maxFactor", maxFactor)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageRandomColorJitter(Symbol data, float brightness, float contrast, float saturation, float hue, string symbol_name = null)
        {
            return new Operator("_image_random_color_jitter")
                .SetInput(data)
                .SetParam("brightness", brightness)
                .SetParam("contrast", contrast)
                .SetParam("saturation", saturation)
                .SetParam("hue", hue)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageAdjustLighting(Symbol data, object alpha, string symbol_name = null)
        {
            return new Operator("_image_adjust_lighting")
                .SetInput(data)
                .SetParam("alpha", alpha)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageRandomLighting(Symbol data, float alphaStd, string symbol_name = null)
        {
            return new Operator("_image_random_lighting")
                .SetInput(data)
                .SetParam("alphaStd", alphaStd)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imageResize(Symbol data, Shape size, bool keepRatio, int interp, string symbol_name = null)
        {
            return new Operator("_image_resize")
                .SetInput(data)
                .SetParam("size", size)
                .SetParam("keepRatio", keepRatio)
                .SetParam("interp", interp)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSoftmaxCrossEntropy(string symbol_name = null)
        {
            return new Operator("_backward_softmax_cross_entropy")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardActivation(string symbol_name = null)
        {
            return new Operator("_backward_Activation")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBatchNorm(string symbol_name = null)
        {
            return new Operator("_backward_BatchNorm")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardConcat(string symbol_name = null)
        {
            return new Operator("_backward_Concat")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _rnnParamConcat(SymbolList data, int numArgs, int dim, string symbol_name = null)
        {
            return new Operator("_rnn_param_concat")
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("dim", dim)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardConvolution(string symbol_name = null)
        {
            return new Operator("_backward_Convolution")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCtcLoss(string symbol_name = null)
        {
            return new Operator("_backward_ctc_loss")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardDeconvolution(string symbol_name = null)
        {
            return new Operator("_backward_Deconvolution")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardDropout(string symbol_name = null)
        {
            return new Operator("_backward_Dropout")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardFullyConnected(string symbol_name = null)
        {
            return new Operator("_backward_FullyConnected")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLayerNorm(string symbol_name = null)
        {
            return new Operator("_backward_LayerNorm")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLRN(string symbol_name = null)
        {
            return new Operator("_backward_LRN")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMoments(string symbol_name = null)
        {
            return new Operator("_backward_moments")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardPooling(string symbol_name = null)
        {
            return new Operator("_backward_Pooling")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSoftmax(SymbolList args, string symbol_name = null)
        {
            return new Operator("_backward_softmax")
                .SetInput(args)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSoftmin(SymbolList args, string symbol_name = null)
        {
            return new Operator("_backward_softmin")
                .SetInput(args)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLogSoftmax(SymbolList args, string symbol_name = null)
        {
            return new Operator("_backward_log_softmax")
                .SetInput(args)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSoftmaxActivation(string symbol_name = null)
        {
            return new Operator("_backward_SoftmaxActivation")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardUpSampling(string symbol_name = null)
        {
            return new Operator("_backward_UpSampling")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sparseAdagradUpdate(Symbol weight, Symbol grad, Symbol history, float lr, float epsilon, float wd, float rescaleGrad, float clipGradient, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribDequantize(Symbol data, Symbol minRange, Symbol maxRange, string outType, string symbol_name = null)
        {
            return new Operator("_contrib_dequantize")
                .SetInput(data)
                .SetInput(minRange)
                .SetInput(maxRange)
                .SetParam("outType", outType)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuantize(Symbol data, Symbol minRange, Symbol maxRange, string outType, string symbol_name = null)
        {
            return new Operator("_contrib_quantize")
                .SetInput(data)
                .SetInput(minRange)
                .SetInput(maxRange)
                .SetParam("outType", outType)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuantizeV2(Symbol data, string outType, float minCalibRange, float maxCalibRange, string symbol_name = null)
        {
            return new Operator("_contrib_quantize_v2")
                .SetInput(data)
                .SetParam("outType", outType)
                .SetParam("minCalibRange", minCalibRange)
                .SetParam("maxCalibRange", maxCalibRange)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuantizedAct(Symbol data, Symbol minData, Symbol maxData, string actType, string symbol_name = null)
        {
            return new Operator("_contrib_quantized_act")
                .SetInput(data)
                .SetInput(minData)
                .SetInput(maxData)
                .SetParam("actType", actType)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuantizedConcat(SymbolList data, int numArgs, int dim, string symbol_name = null)
        {
            return new Operator("_contrib_quantized_concat")
                .SetInput(data)
                .SetParam("numArgs", numArgs)
                .SetParam("dim", dim)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuantizedConv(Symbol data, Symbol weight, Symbol bias, Symbol minData, Symbol maxData, Symbol minWeight, Symbol maxWeight, Symbol minBias, Symbol maxBias, Shape kernel, Shape stride, Shape dilate, Shape pad, int numFilter, int numGroup, long workspace, bool noBias, string cudnnTune, bool cudnnOff, string layout, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuantizedElemwiseAdd(Symbol lhs, Symbol rhs, Symbol lhsMin, Symbol lhsMax, Symbol rhsMin, Symbol rhsMax, string symbol_name = null)
        {
            return new Operator("_contrib_quantized_elemwise_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetInput(lhsMin)
                .SetInput(lhsMax)
                .SetInput(rhsMin)
                .SetInput(rhsMax)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuantizedFlatten(Symbol data, Symbol minData, Symbol maxData, string symbol_name = null)
        {
            return new Operator("_contrib_quantized_flatten")
                .SetInput(data)
                .SetInput(minData)
                .SetInput(maxData)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuantizedFullyConnected(Symbol data, Symbol weight, Symbol bias, Symbol minData, Symbol maxData, Symbol minWeight, Symbol maxWeight, Symbol minBias, Symbol maxBias, int numHidden, bool noBias, bool flatten, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribQuantizedPooling(Symbol data, Symbol minData, Symbol maxData, Shape kernel, string poolType, bool globalPool, bool cudnnOff, string poolingConvention, Shape stride, Shape pad, int pValue, bool countIncludePad, string layout, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribRequantize(Symbol data, Symbol minRange, Symbol maxRange, string outType, float minCalibRange, float maxCalibRange, string symbol_name = null)
        {
            return new Operator("_contrib_requantize")
                .SetInput(data)
                .SetInput(minRange)
                .SetInput(maxRange)
                .SetParam("outType", outType)
                .SetParam("minCalibRange", minCalibRange)
                .SetParam("maxCalibRange", maxCalibRange)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sampleUniform(Symbol low, Shape shape, string dtype, Symbol high, string symbol_name = null)
        {
            return new Operator("_sample_uniform")
                .SetInput(low)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(high)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sampleNormal(Symbol mu, Shape shape, string dtype, Symbol sigma, string symbol_name = null)
        {
            return new Operator("_sample_normal")
                .SetInput(mu)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(sigma)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sampleGamma(Symbol alpha, Shape shape, string dtype, Symbol beta, string symbol_name = null)
        {
            return new Operator("_sample_gamma")
                .SetInput(alpha)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(beta)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sampleExponential(Symbol lam, Shape shape, string dtype, string symbol_name = null)
        {
            return new Operator("_sample_exponential")
                .SetInput(lam)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _samplePoisson(Symbol lam, Shape shape, string dtype, string symbol_name = null)
        {
            return new Operator("_sample_poisson")
                .SetInput(lam)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sampleNegativeBinomial(Symbol k, Shape shape, string dtype, Symbol p, string symbol_name = null)
        {
            return new Operator("_sample_negative_binomial")
                .SetInput(k)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(p)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sampleGeneralizedNegativeBinomial(Symbol mu, Shape shape, string dtype, Symbol alpha, string symbol_name = null)
        {
            return new Operator("_sample_generalized_negative_binomial")
                .SetInput(mu)
                .SetParam("shape", shape)
                .SetParam("dtype", dtype)
                .SetInput(alpha)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sampleMultinomial(Symbol data, Shape shape, bool getProb, string dtype, string symbol_name = null)
        {
            return new Operator("_sample_multinomial")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("getProb", getProb)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSampleMultinomial(string symbol_name = null)
        {
            return new Operator("_backward_sample_multinomial")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomUniform(float low, float high, Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_random_uniform")
                .SetParam("low", low)
                .SetParam("high", high)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomNormal(float loc, float scale, Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_random_normal")
                .SetParam("loc", loc)
                .SetParam("scale", scale)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomGamma(float alpha, float beta, Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_random_gamma")
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomExponential(float lam, Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_random_exponential")
                .SetParam("lam", lam)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomPoisson(float lam, Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_random_poisson")
                .SetParam("lam", lam)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomNegativeBinomial(int k, float p, Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_random_negative_binomial")
                .SetParam("k", k)
                .SetParam("p", p)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomGeneralizedNegativeBinomial(float mu, float alpha, Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_random_generalized_negative_binomial")
                .SetParam("mu", mu)
                .SetParam("alpha", alpha)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomRandint(object low, object high, Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_random_randint")
                .SetParam("low", low)
                .SetParam("high", high)
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomUniformLike(float low, float high, Symbol data, string symbol_name = null)
        {
            return new Operator("_random_uniform_like")
                .SetParam("low", low)
                .SetParam("high", high)
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomNormalLike(float loc, float scale, Symbol data, string symbol_name = null)
        {
            return new Operator("_random_normal_like")
                .SetParam("loc", loc)
                .SetParam("scale", scale)
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomGammaLike(float alpha, float beta, Symbol data, string symbol_name = null)
        {
            return new Operator("_random_gamma_like")
                .SetParam("alpha", alpha)
                .SetParam("beta", beta)
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomExponentialLike(float lam, Symbol data, string symbol_name = null)
        {
            return new Operator("_random_exponential_like")
                .SetParam("lam", lam)
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomPoissonLike(float lam, Symbol data, string symbol_name = null)
        {
            return new Operator("_random_poisson_like")
                .SetParam("lam", lam)
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomNegativeBinomialLike(int k, float p, Symbol data, string symbol_name = null)
        {
            return new Operator("_random_negative_binomial_like")
                .SetParam("k", k)
                .SetParam("p", p)
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _randomGeneralizedNegativeBinomialLike(float mu, float alpha, Symbol data, string symbol_name = null)
        {
            return new Operator("_random_generalized_negative_binomial_like")
                .SetParam("mu", mu)
                .SetParam("alpha", alpha)
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _shuffle(Symbol data, string symbol_name = null)
        {
            return new Operator("_shuffle")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sampleUniqueZipfian(int rangeMax, Shape shape, string symbol_name = null)
        {
            return new Operator("_sample_unique_zipfian")
                .SetParam("rangeMax", rangeMax)
                .SetParam("shape", shape)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinearRegOut(string symbol_name = null)
        {
            return new Operator("_backward_linear_reg_out")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMaeRegOut(string symbol_name = null)
        {
            return new Operator("_backward_mae_reg_out")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLogisticRegOut(string symbol_name = null)
        {
            return new Operator("_backward_logistic_reg_out")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardRNN(string symbol_name = null)
        {
            return new Operator("_backward_RNN")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSoftmaxOutput(string symbol_name = null)
        {
            return new Operator("_backward_SoftmaxOutput")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardAmpCast(string symbol_name = null)
        {
            return new Operator("_backward_amp_cast")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardAmpMulticast(SymbolList grad, int numOutputs, string symbol_name = null)
        {
            return new Operator("_backward_amp_multicast")
                .SetInput(grad)
                .SetParam("numOutputs", numOutputs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardPick(string symbol_name = null)
        {
            return new Operator("_backward_pick")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSum(string symbol_name = null)
        {
            return new Operator("_backward_sum")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMean(string symbol_name = null)
        {
            return new Operator("_backward_mean")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardProd(string symbol_name = null)
        {
            return new Operator("_backward_prod")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardNansum(string symbol_name = null)
        {
            return new Operator("_backward_nansum")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardNanprod(string symbol_name = null)
        {
            return new Operator("_backward_nanprod")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMax(string symbol_name = null)
        {
            return new Operator("_backward_max")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMin(string symbol_name = null)
        {
            return new Operator("_backward_min")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _broadcastBackward(string symbol_name = null)
        {
            return new Operator("_broadcast_backward")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardNorm(string symbol_name = null)
        {
            return new Operator("_backward_norm")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardWhere(string symbol_name = null)
        {
            return new Operator("_backward_where")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardDiag(string symbol_name = null)
        {
            return new Operator("_backward_diag")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardDot(bool transposea, bool transposeb, string forwardStype, string symbol_name = null)
        {
            return new Operator("_backward_dot")
                .SetParam("transposea", transposea)
                .SetParam("transposeb", transposeb)
                .SetParam("forwardStype", forwardStype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBatchDot(string symbol_name = null)
        {
            return new Operator("_backward_batch_dot")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBroadcastAdd(string symbol_name = null)
        {
            return new Operator("_backward_broadcast_add")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBroadcastSub(string symbol_name = null)
        {
            return new Operator("_backward_broadcast_sub")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBroadcastMul(string symbol_name = null)
        {
            return new Operator("_backward_broadcast_mul")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBroadcastDiv(string symbol_name = null)
        {
            return new Operator("_backward_broadcast_div")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBroadcastMod(string symbol_name = null)
        {
            return new Operator("_backward_broadcast_mod")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBroadcastPower(string symbol_name = null)
        {
            return new Operator("_backward_broadcast_power")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBroadcastMaximum(string symbol_name = null)
        {
            return new Operator("_backward_broadcast_maximum")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBroadcastMinimum(string symbol_name = null)
        {
            return new Operator("_backward_broadcast_minimum")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBroadcastHypot(string symbol_name = null)
        {
            return new Operator("_backward_broadcast_hypot")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _gradAdd(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_grad_add")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardAdd(string symbol_name = null)
        {
            return new Operator("_backward_add")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSub(string symbol_name = null)
        {
            return new Operator("_backward_sub")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMul(string symbol_name = null)
        {
            return new Operator("_backward_mul")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardDiv(string symbol_name = null)
        {
            return new Operator("_backward_div")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _mod(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_mod")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMod(string symbol_name = null)
        {
            return new Operator("_backward_mod")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _power(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_power")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardPower(string symbol_name = null)
        {
            return new Operator("_backward_power")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _maximum(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_maximum")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMaximum(string symbol_name = null)
        {
            return new Operator("_backward_maximum")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _minimum(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_minimum")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMinimum(string symbol_name = null)
        {
            return new Operator("_backward_minimum")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _hypot(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_hypot")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardHypot(string symbol_name = null)
        {
            return new Operator("_backward_hypot")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _equal(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _notEqual(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_not_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _greater(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_greater")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _greaterEqual(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_greater_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _lesser(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_lesser")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _lesserEqual(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_lesser_equal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _logicalAnd(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_logical_and")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _logicalOr(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_logical_or")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _logicalXor(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_logical_xor")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _plusScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_plus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _minusScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_minus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _rminusScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_rminus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _mulScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_mul_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMulScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_mul_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _divScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_div_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardDivScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_div_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _rdivScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_rdiv_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardRdivScalar(Symbol lhs, Symbol rhs, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_rdiv_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _modScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_mod_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardModScalar(Symbol lhs, Symbol rhs, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_mod_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _rmodScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_rmod_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardRmodScalar(Symbol lhs, Symbol rhs, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_rmod_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _maximumScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_maximum_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMaximumScalar(Symbol lhs, Symbol rhs, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_maximum_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _minimumScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_minimum_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMinimumScalar(Symbol lhs, Symbol rhs, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_minimum_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _powerScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_power_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardPowerScalar(Symbol lhs, Symbol rhs, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_power_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _rpowerScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_rpower_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardRpowerScalar(Symbol lhs, Symbol rhs, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_rpower_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _hypotScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_hypot_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardHypotScalar(Symbol lhs, Symbol rhs, float scalar, string symbol_name = null)
        {
            return new Operator("_backward_hypot_scalar")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSmoothL1(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_smooth_l1")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _equalScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_equal_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _notEqualScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_not_equal_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _greaterScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_greater_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _greaterEqualScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_greater_equal_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _lesserScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_lesser_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _lesserEqualScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_lesser_equal_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _logicalAndScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_logical_and_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _logicalOrScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_logical_or_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _logicalXorScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_logical_xor_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _scatterElemwiseDiv(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_scatter_elemwise_div")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _scatterPlusScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_scatter_plus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _scatterMinusScalar(Symbol data, float scalar, string symbol_name = null)
        {
            return new Operator("_scatter_minus_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardRelu(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_relu")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSigmoid(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_sigmoid")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardHardSigmoid(string symbol_name = null)
        {
            return new Operator("_backward_hard_sigmoid")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSoftsign(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_softsign")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _copy(Symbol data, string symbol_name = null)
        {
            return new Operator("_copy")
                .SetInput(data)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCopy(string symbol_name = null)
        {
            return new Operator("_backward_copy")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardReshape(string symbol_name = null)
        {
            return new Operator("_backward_reshape")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _identityWithAttrLikeRhs(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_identity_with_attr_like_rhs")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCast(string symbol_name = null)
        {
            return new Operator("_backward_cast")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardReciprocal(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_reciprocal")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardAbs(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_abs")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSign(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_sign")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSquare(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_square")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSqrt(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_sqrt")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardRsqrt(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_rsqrt")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCbrt(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_cbrt")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardErf(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_erf")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardErfinv(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_erfinv")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardRcbrt(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_rcbrt")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLog(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_log")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLog10(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_log10")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLog2(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_log2")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLog1p(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_log1p")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardExpm1(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_expm1")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardGamma(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_gamma")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardGammaln(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_gammaln")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSin(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_sin")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCos(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_cos")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardTan(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_tan")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardArcsin(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_arcsin")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardArccos(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_arccos")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardArctan(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_arctan")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardDegrees(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_degrees")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardRadians(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_radians")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSinh(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_sinh")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCosh(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_cosh")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardTanh(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_tanh")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardArcsinh(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_arcsinh")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardArccosh(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_arccosh")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardArctanh(Symbol lhs, Symbol rhs, string symbol_name = null)
        {
            return new Operator("_backward_arctanh")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _histogram(Symbol data, Symbol bins, int binCnt, object range, string symbol_name = null)
        {
            return new Operator("_histogram")
                .SetInput(data)
                .SetInput(bins)
                .SetParam("binCnt", binCnt)
                .SetParam("range", range)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribSparseEmbedding(Symbol data, Symbol weight, int inputDim, int outputDim, string dtype, bool sparseGrad, string symbol_name = null)
        {
            return new Operator("_contrib_SparseEmbedding")
                .SetInput(data)
                .SetInput(weight)
                .SetParam("inputDim", inputDim)
                .SetParam("outputDim", outputDim)
                .SetParam("dtype", dtype)
                .SetParam("sparseGrad", sparseGrad)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardEmbedding(string symbol_name = null)
        {
            return new Operator("_backward_Embedding")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSparseEmbedding(string symbol_name = null)
        {
            return new Operator("_backward_SparseEmbedding")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardTake(string symbol_name = null)
        {
            return new Operator("_backward_take")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardGatherNd(Symbol data, Symbol indices, Shape shape, string symbol_name = null)
        {
            return new Operator("_backward_gather_nd")
                .SetInput(data)
                .SetInput(indices)
                .SetParam("shape", shape)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _scatterSetNd(Symbol lhs, Symbol rhs, Symbol indices, Shape shape, string symbol_name = null)
        {
            return new Operator("_scatter_set_nd")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetInput(indices)
                .SetParam("shape", shape)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _zerosWithoutDtype(Shape shape, string ctx, int dtype, string symbol_name = null)
        {
            return new Operator("_zeros_without_dtype")
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _zeros(Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_zeros")
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _eye(object N, object M, object k, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_eye")
                .SetParam("N", N)
                .SetParam("M", M)
                .SetParam("k", k)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _ones(Shape shape, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_ones")
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _full(Shape shape, string ctx, string dtype, double value, string symbol_name = null)
        {
            return new Operator("_full")
                .SetParam("shape", shape)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("value", value)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _arange(double start, double stop, double step, int repeat, bool inferRange, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_arange")
                .SetParam("start", start)
                .SetParam("stop", stop)
                .SetParam("step", step)
                .SetParam("repeat", repeat)
                .SetParam("inferRange", inferRange)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linspace(double start, double stop, double step, int repeat, bool inferRange, string ctx, string dtype, string symbol_name = null)
        {
            return new Operator("_linspace")
                .SetParam("start", start)
                .SetParam("stop", stop)
                .SetParam("step", step)
                .SetParam("repeat", repeat)
                .SetParam("inferRange", inferRange)
                .SetParam("ctx", ctx)
                .SetParam("dtype", dtype)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgGemm(Symbol A, Symbol B, Symbol C, bool transposea, bool transposeb, double alpha, double beta, int axis, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgGemm(string symbol_name = null)
        {
            return new Operator("_backward_linalg_gemm")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgGemm2(Symbol A, Symbol B, bool transposea, bool transposeb, double alpha, int axis, string symbol_name = null)
        {
            return new Operator("_linalg_gemm2")
                .SetInput(A)
                .SetInput(B)
                .SetParam("transposea", transposea)
                .SetParam("transposeb", transposeb)
                .SetParam("alpha", alpha)
                .SetParam("axis", axis)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgGemm2(string symbol_name = null)
        {
            return new Operator("_backward_linalg_gemm2")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgPotrf(Symbol A, string symbol_name = null)
        {
            return new Operator("_linalg_potrf")
                .SetInput(A)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgPotrf(string symbol_name = null)
        {
            return new Operator("_backward_linalg_potrf")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgPotri(Symbol A, string symbol_name = null)
        {
            return new Operator("_linalg_potri")
                .SetInput(A)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgPotri(string symbol_name = null)
        {
            return new Operator("_backward_linalg_potri")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgTrmm(Symbol A, Symbol B, bool transpose, bool rightside, bool lower, double alpha, string symbol_name = null)
        {
            return new Operator("_linalg_trmm")
                .SetInput(A)
                .SetInput(B)
                .SetParam("transpose", transpose)
                .SetParam("rightside", rightside)
                .SetParam("lower", lower)
                .SetParam("alpha", alpha)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgTrmm(string symbol_name = null)
        {
            return new Operator("_backward_linalg_trmm")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgTrsm(Symbol A, Symbol B, bool transpose, bool rightside, bool lower, double alpha, string symbol_name = null)
        {
            return new Operator("_linalg_trsm")
                .SetInput(A)
                .SetInput(B)
                .SetParam("transpose", transpose)
                .SetParam("rightside", rightside)
                .SetParam("lower", lower)
                .SetParam("alpha", alpha)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgTrsm(string symbol_name = null)
        {
            return new Operator("_backward_linalg_trsm")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgSumlogdiag(Symbol A, string symbol_name = null)
        {
            return new Operator("_linalg_sumlogdiag")
                .SetInput(A)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgSumlogdiag(string symbol_name = null)
        {
            return new Operator("_backward_linalg_sumlogdiag")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgExtractdiag(Symbol A, int offset, string symbol_name = null)
        {
            return new Operator("_linalg_extractdiag")
                .SetInput(A)
                .SetParam("offset", offset)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgExtractdiag(string symbol_name = null)
        {
            return new Operator("_backward_linalg_extractdiag")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgMakediag(Symbol A, int offset, string symbol_name = null)
        {
            return new Operator("_linalg_makediag")
                .SetInput(A)
                .SetParam("offset", offset)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgMakediag(string symbol_name = null)
        {
            return new Operator("_backward_linalg_makediag")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgExtracttrian(Symbol A, int offset, bool lower, string symbol_name = null)
        {
            return new Operator("_linalg_extracttrian")
                .SetInput(A)
                .SetParam("offset", offset)
                .SetParam("lower", lower)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgExtracttrian(string symbol_name = null)
        {
            return new Operator("_backward_linalg_extracttrian")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgMaketrian(Symbol A, int offset, bool lower, string symbol_name = null)
        {
            return new Operator("_linalg_maketrian")
                .SetInput(A)
                .SetParam("offset", offset)
                .SetParam("lower", lower)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgMaketrian(string symbol_name = null)
        {
            return new Operator("_backward_linalg_maketrian")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgSyrk(Symbol A, bool transpose, double alpha, string symbol_name = null)
        {
            return new Operator("_linalg_syrk")
                .SetInput(A)
                .SetParam("transpose", transpose)
                .SetParam("alpha", alpha)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgSyrk(string symbol_name = null)
        {
            return new Operator("_backward_linalg_syrk")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgGelqf(Symbol A, string symbol_name = null)
        {
            return new Operator("_linalg_gelqf")
                .SetInput(A)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgGelqf(string symbol_name = null)
        {
            return new Operator("_backward_linalg_gelqf")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgSyevd(Symbol A, string symbol_name = null)
        {
            return new Operator("_linalg_syevd")
                .SetInput(A)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgSyevd(string symbol_name = null)
        {
            return new Operator("_backward_linalg_syevd")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _linalgInverse(Symbol A, string symbol_name = null)
        {
            return new Operator("_linalg_inverse")
                .SetInput(A)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLinalgInverse(string symbol_name = null)
        {
            return new Operator("_backward_linalg_inverse")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSlice(string symbol_name = null)
        {
            return new Operator("_backward_slice")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sliceAssign(Symbol lhs, Symbol rhs, Shape begin, Shape end, Shape step, string symbol_name = null)
        {
            return new Operator("_slice_assign")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetParam("step", step)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sliceAssignScalar(Symbol data, double scalar, Shape begin, Shape end, Shape step, string symbol_name = null)
        {
            return new Operator("_slice_assign_scalar")
                .SetInput(data)
                .SetParam("scalar", scalar)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetParam("step", step)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSliceAxis(string symbol_name = null)
        {
            return new Operator("_backward_slice_axis")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSliceLike(string symbol_name = null)
        {
            return new Operator("_backward_slice_like")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardClip(string symbol_name = null)
        {
            return new Operator("_backward_clip")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardRepeat(string symbol_name = null)
        {
            return new Operator("_backward_repeat")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardTile(string symbol_name = null)
        {
            return new Operator("_backward_tile")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardReverse(string symbol_name = null)
        {
            return new Operator("_backward_reverse")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardStack(string symbol_name = null)
        {
            return new Operator("_backward_stack")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSqueeze(string symbol_name = null)
        {
            return new Operator("_backward_squeeze")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _splitV2(Symbol data, Shape indices, int axis, bool squeezeAxis, int sections, string symbol_name = null)
        {
            return new Operator("_split_v2")
                .SetInput(data)
                .SetParam("indices", indices)
                .SetParam("axis", axis)
                .SetParam("squeezeAxis", squeezeAxis)
                .SetParam("sections", sections)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _splitV2Backward(string symbol_name = null)
        {
            return new Operator("_split_v2_backward")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardTopk(string symbol_name = null)
        {
            return new Operator("_backward_topk")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _ravelMultiIndex(Symbol data, Shape shape, string symbol_name = null)
        {
            return new Operator("_ravel_multi_index")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _unravelIndex(Symbol data, Shape shape, string symbol_name = null)
        {
            return new Operator("_unravel_index")
                .SetInput(data)
                .SetParam("shape", shape)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _sparseRetain(Symbol data, Symbol indices, string symbol_name = null)
        {
            return new Operator("_sparse_retain")
                .SetInput(data)
                .SetInput(indices)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSparseRetain(string symbol_name = null)
        {
            return new Operator("_backward_sparse_retain")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _squareSum(Symbol data, Shape axis, bool keepdims, bool exclude, string symbol_name = null)
        {
            return new Operator("_square_sum")
                .SetInput(data)
                .SetParam("axis", axis)
                .SetParam("keepdims", keepdims)
                .SetParam("exclude", exclude)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSquareSum(string symbol_name = null)
        {
            return new Operator("_backward_square_sum")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBatchNormV1(string symbol_name = null)
        {
            return new Operator("_backward_BatchNorm_v1")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardBilinearSampler(string symbol_name = null)
        {
            return new Operator("_backward_BilinearSampler")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribCountSketch(Symbol data, Symbol h, Symbol s, int outDim, int processingBatchSize, string symbol_name = null)
        {
            return new Operator("_contrib_count_sketch")
                .SetInput(data)
                .SetInput(h)
                .SetInput(s)
                .SetParam("outDim", outDim)
                .SetParam("processingBatchSize", processingBatchSize)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribCountSketch(string symbol_name = null)
        {
            return new Operator("_backward__contrib_count_sketch")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribDeformableConvolution(Symbol data, Symbol offset, Symbol weight, Symbol bias, Shape kernel, Shape stride, Shape dilate, Shape pad, int numFilter, int numGroup, int numDeformableGroup, long workspace, bool noBias, string layout, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribDeformableConvolution(string symbol_name = null)
        {
            return new Operator("_backward__contrib_DeformableConvolution")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribDeformablePSROIPooling(Symbol data, Symbol rois, Symbol trans, float spatialScale, int outputDim, int groupSize, int pooledSize, int partSize, int samplePerPart, float transStd, bool noTrans, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribDeformablePSROIPooling(string symbol_name = null)
        {
            return new Operator("_backward__contrib_DeformablePSROIPooling")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribFft(Symbol data, int computeSize, string symbol_name = null)
        {
            return new Operator("_contrib_fft")
                .SetInput(data)
                .SetParam("computeSize", computeSize)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribFft(string symbol_name = null)
        {
            return new Operator("_backward__contrib_fft")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribIfft(Symbol data, int computeSize, string symbol_name = null)
        {
            return new Operator("_contrib_ifft")
                .SetInput(data)
                .SetParam("computeSize", computeSize)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribIfft(string symbol_name = null)
        {
            return new Operator("_backward__contrib_ifft")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribMultiProposal(Symbol clsProb, Symbol bboxPred, Symbol imInfo, int rpnPreNmsTopn, int rpnPostNmsTopn, float threshold, int rpnMinSize, object scales, object ratios, int featureStride, bool outputScore, bool iouLoss, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribMultiProposal(string symbol_name = null)
        {
            return new Operator("_backward__contrib_MultiProposal")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribMultiBoxDetection(Symbol clsProb, Symbol locPred, Symbol anchor, bool clip, float threshold, int backgroundId, float nmsThreshold, bool forceSuppress, object variances, int nmsTopk, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribMultiBoxDetection(string symbol_name = null)
        {
            return new Operator("_backward__contrib_MultiBoxDetection")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribMultiBoxPrior(Symbol data, object sizes, object ratios, bool clip, object steps, object offsets, string symbol_name = null)
        {
            return new Operator("_contrib_MultiBoxPrior")
                .SetInput(data)
                .SetParam("sizes", sizes)
                .SetParam("ratios", ratios)
                .SetParam("clip", clip)
                .SetParam("steps", steps)
                .SetParam("offsets", offsets)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribMultiBoxPrior(string symbol_name = null)
        {
            return new Operator("_backward__contrib_MultiBoxPrior")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribMultiBoxTarget(Symbol anchor, Symbol label, Symbol clsPred, float overlapThreshold, float ignoreLabel, float negativeMiningRatio, float negativeMiningThresh, int minimumNegativeSamples, object variances, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribMultiBoxTarget(string symbol_name = null)
        {
            return new Operator("_backward__contrib_MultiBoxTarget")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribProposal(Symbol clsProb, Symbol bboxPred, Symbol imInfo, int rpnPreNmsTopn, int rpnPostNmsTopn, float threshold, int rpnMinSize, object scales, object ratios, int featureStride, bool outputScore, bool iouLoss, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribProposal(string symbol_name = null)
        {
            return new Operator("_backward__contrib_Proposal")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _contribPSROIPooling(Symbol data, Symbol rois, float spatialScale, int outputDim, int pooledSize, int groupSize, string symbol_name = null)
        {
            return new Operator("_contrib_PSROIPooling")
                .SetInput(data)
                .SetInput(rois)
                .SetParam("spatialScale", spatialScale)
                .SetParam("outputDim", outputDim)
                .SetParam("pooledSize", pooledSize)
                .SetParam("groupSize", groupSize)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribPSROIPooling(string symbol_name = null)
        {
            return new Operator("_backward__contrib_PSROIPooling")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardContribSyncBatchNorm(string symbol_name = null)
        {
            return new Operator("_backward__contrib_SyncBatchNorm")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardConvolutionV1(string symbol_name = null)
        {
            return new Operator("_backward_Convolution_v1")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCorrelation(string symbol_name = null)
        {
            return new Operator("_backward_Correlation")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCrop(string symbol_name = null)
        {
            return new Operator("_backward_Crop")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _CrossDeviceCopy(string symbol_name = null)
        {
            return new Operator("_CrossDeviceCopy")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardCrossDeviceCopy(string symbol_name = null)
        {
            return new Operator("_backward__CrossDeviceCopy")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _Native(SymbolList data, IntPtr info, bool needTopGrad, string symbol_name = null)
        {
            return new Operator("_Native")
                .SetInput(data)
                .SetParam("info", info)
                .SetParam("needTopGrad", needTopGrad)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardNative(string symbol_name = null)
        {
            return new Operator("_backward__Native")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _NDArray(SymbolList data, IntPtr info, string symbol_name = null)
        {
            return new Operator("_NDArray")
                .SetInput(data)
                .SetParam("info", info)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardNDArray(string symbol_name = null)
        {
            return new Operator("_backward__NDArray")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardGridGenerator(string symbol_name = null)
        {
            return new Operator("_backward_GridGenerator")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardIdentityAttachKLSparseReg(string symbol_name = null)
        {
            return new Operator("_backward_IdentityAttachKLSparseReg")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardInstanceNorm(string symbol_name = null)
        {
            return new Operator("_backward_InstanceNorm")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardL2Normalization(string symbol_name = null)
        {
            return new Operator("_backward_L2Normalization")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardLeakyReLU(string symbol_name = null)
        {
            return new Operator("_backward_LeakyReLU")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardMakeLoss(string symbol_name = null)
        {
            return new Operator("_backward_MakeLoss")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardPad(string symbol_name = null)
        {
            return new Operator("_backward_Pad")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardPoolingV1(string symbol_name = null)
        {
            return new Operator("_backward_Pooling_v1")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardROIPooling(string symbol_name = null)
        {
            return new Operator("_backward_ROIPooling")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSequenceLast(string symbol_name = null)
        {
            return new Operator("_backward_SequenceLast")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSequenceMask(string symbol_name = null)
        {
            return new Operator("_backward_SequenceMask")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSequenceReverse(string symbol_name = null)
        {
            return new Operator("_backward_SequenceReverse")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSliceChannel(string symbol_name = null)
        {
            return new Operator("_backward_SliceChannel")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSpatialTransformer(string symbol_name = null)
        {
            return new Operator("_backward_SpatialTransformer")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSVMOutput(string symbol_name = null)
        {
            return new Operator("_backward_SVMOutput")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _backwardSwapAxis(string symbol_name = null)
        {
            return new Operator("_backward_SwapAxis")
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _setValue(float src, string symbol_name = null)
        {
            return new Operator("_set_value")
                .SetParam("src", src)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _onehotEncode(NDArray lhs, NDArray rhs, string symbol_name = null)
        {
            return new Operator("_onehot_encode")
                .SetInput(lhs)
                .SetInput(rhs)
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        public static SymbolList _imdecode(Symbol mean, int index, int x0, int y0, int x1, int y1, int c, int size, string symbol_name = null)
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
                .SetParam("symbol_name", symbol_name)
                .CreateSymbol(symbol_name);
        }

        }
    }
}
