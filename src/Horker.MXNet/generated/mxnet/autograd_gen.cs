using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Horker.MXNet;
using Horker.MXNet.Compat;
using Horker.MXNet.Interop;
using static Horker.MXNet.Compat.Compat;
using static Horker.MXNet.Compat.Coercing;
using static Horker.MXNet.MXNetCoercing;
using static Horker.MXNet.MXNetCompat;
using static Horker.MXNet.DType;

namespace Horker.MXNet
{
    using Int = System.Int32;
    using List = System.Array;
    using static Helper;
    public static partial class Helper {}
    
    // Expr
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // Import
    // Import
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    
    public static partial class Helper
    {
        public static bool SetRecording(int isRecording)
        {
            // Expr
            var prev = CTypes.CInt();
            CheckCall(LIB.MXAutogradSetIsRecording(CTypes.CInt(isRecording), ref prev));
            return Bool(prev);
        }
    }
    
    public static partial class Helper
    {
        public static bool SetTraining(int trainMode)
        {
            // Expr
            var prev = CTypes.CInt();
            CheckCall(LIB.MXAutogradSetIsTraining(CTypes.CInt(trainMode), ref prev));
            return Bool(prev);
        }
    }
    
    public static partial class Helper
    {
        public static bool IsRecording()
        {
            // Expr
            var curr = CTypes.CBool();
            CheckCall(LIB.MXAutogradIsRecording(ref curr));
            return curr;
        }
    }
    
    public static partial class Helper
    {
        public static bool IsTraining()
        {
            // Expr
            var curr = CTypes.CBool();
            CheckCall(LIB.MXAutogradIsTraining(ref curr));
            return curr;
        }
    }
    
    public partial class RecordingStateScope
    {
        private int _enterIsRecord;
        private int _enterTrainMode;
        private int _prevIsRecord;
        private int _prevTrainMode;
        
        // Expr
        
        public RecordingStateScope(bool isRecord, bool trainMode)
        {
            this._enterIsRecord = CoerceIntoInt(isRecord);
            this._enterTrainMode = CoerceIntoInt(trainMode);
            this._prevIsRecord = CoerceIntoInt(null);
            this._prevTrainMode = CoerceIntoInt(null);
        }
        
        public void Enter()
        {
            if (IsTrue((!IsNone(this._enterIsRecord)))){
                this._prevIsRecord = CoerceIntoInt(SetRecording(this._enterIsRecord));
            }
            if (IsTrue((!IsNone(this._enterTrainMode)))){
                this._prevTrainMode = CoerceIntoInt(SetTraining(this._enterTrainMode));
            }
        }
        
        public void Exit(object ptype, object value, object trace)
        {
            if (IsTrue((IsTrue((!IsNone(this._enterIsRecord))) && IsTrue((this._prevIsRecord != this._enterIsRecord))))){
                SetRecording(this._prevIsRecord);
            }
            if (IsTrue((IsTrue((!IsNone(this._enterTrainMode))) && IsTrue((this._prevTrainMode != this._enterTrainMode))))){
                SetTraining(this._prevTrainMode);
            }
        }
    }
    
    public static partial class Helper
    {
        public static RecordingStateScope Record(bool trainMode = true)
        {
            // Expr
            return new RecordingStateScope(true, trainMode);
        }
    }
    
    public static partial class Helper
    {
        public static RecordingStateScope Pause(bool trainMode = false)
        {
            // Expr
            return new RecordingStateScope(false, trainMode);
        }
    }
    
    public static partial class Helper
    {
        public static RecordingStateScope TrainMode()
        {
            // Expr
            return new RecordingStateScope(null, true);
        }
    }
    
    public static partial class Helper
    {
        public static RecordingStateScope PredictMode()
        {
            // Expr
            return new RecordingStateScope(null, false);
        }
    }
    
    public static partial class Helper
    {
        public static  void MarkVariables(NDArrayList variables, NDArrayList gradients, string gradReqs = "write")
        {
            // Expr
            if (IsTrue(Isinstance(variables, typeof(NDArray)))){
                var local0 = (NDArray)variables;
                Assert(Isinstance(gradients, typeof(NDArray)), "Isinstance(gradients, typeof(NDArray))");
                var local1 = (NDArray)gradients;
                variables = new [] { local0 };
                gradients = new [] { local1 };
            }
            if (IsTrue(Isinstance(gradReqs, typeof(StringTypes)))){
                var local0 = (string_types)gradReqs;
                gradReqs = (new [] { GRADREQMAP[local0] } * Len(variables));
            }
            else
            {
                gradReqs = gradReqs.Select(i => GRADREQMAP[i]).ToList();
            }
            CheckCall(LIB.MXAutogradMarkVariables(Len(variables), CHandleArray(variables), CArrayBuf(MxUint, Array("I", gradReqs)), CHandleArray(gradients)));
        }
    }
    
    public static partial class Helper
    {
        private static  object _parseHead(object heads, object headGrads)
        {
            // Expr
            if (IsTrue(Isinstance(heads, typeof(NDArray)))){
                var local0 = (NDArray)heads;
                heads = new [] { local0 };
            }
            if (IsTrue(Isinstance(headGrads, typeof(NDArray)))){
                var local0 = (NDArray)headGrads;
                headGrads = new [] { local0 };
            }
            var headHandles = CHandleArray(heads);
            if (IsTrue((IsNone(headGrads)))){
                var hgradHandles = CTypes.CVoidP(0);
            }
            else
            {
                Assert((Len(heads) == Len(headGrads)), "(Len(heads) == Len(headGrads))");
                var hgradHandles = CArray(typeof(NDArrayHandle), headGrads.Select(i => (IsTrue((!IsNone(i))) ? i.Handle : new NDArrayHandle(0))).ToList());
            }
            return ValueTuple.Create(headHandles, HgradHandles);
        }
    }
    
    public static partial class Helper
    {
        public static  object Backward(object heads, object headGrads = null, bool retainGraph = false, bool trainMode = true)
        {
            // Expr
            var (headHandles, hgradHandles) = _parseHead(heads, headGrads);
            CheckCall(LIB.MXAutogradBackwardEx(Len(headHandles), headHandles, hgradHandles, 0, CTypes.CVoidP(0), CTypes.CInt(retainGraph), CTypes.CInt(0), CTypes.CInt(trainMode), CTypes.CVoidP(0), CTypes.CVoidP(0)));
        }
    }
    
    public static partial class Helper
    {
        public static  object Grad(object heads, object variables, object headGrads = null, object retainGraph = null, bool createGraph = false, bool trainMode = true)
        {
            // Expr
            var (headHandles, hgradHandles) = _parseHead(heads, headGrads);
            if (IsTrue(Isinstance(variables, typeof(NDArray)))){
                var local0 = (NDArray)variables;
                variables = new [] { local0 };
            }
            else
            {
                Assert(Len(variables), "Len(variables)");
            }
            var varHandles = CHandleArray(variables);
            retainGraph = (IsTrue((!IsNone(retainGraph))) ? retainGraph : createGraph);
            var gradVars = CTypes.POINTER(typeof(NDArrayHandle))();
            var gradStypes = CTypes.POINTER(CTypes.CInt)();
            CheckCall(LIB.MXAutogradBackwardEx(Len(headHandles), headHandles, hgradHandles, Len(varHandles), varHandles, CTypes.CInt(retainGraph), CTypes.CInt(createGraph), CTypes.CInt(trainMode), ref gradVars, ref gradStypes));
            var ret = Range(Len(varHandles)).Select(i => _ndarrayCls(CTypes.Cast(gradVars[i], typeof(NDArrayHandle)), stype: gradStypes[i])).ToList();
            if (IsTrue(Isinstance(variables, typeof(NDArray)))){
                var local0 = (NDArray)variables;
                return ret.Item1;
            }
            return ret;
        }
    }
    
    public static partial class Helper
    {
        public static  object GetSymbol(object x)
        {
            // Expr
            var hdl = new SymbolHandle();
            CheckCall(LIB.MXAutogradGetSymbol(x.Handle, ref hdl));
            return new Symbol(hdl);
        }
    }
    // Drop: Function
}
