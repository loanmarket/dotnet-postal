//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


internal class libpostal_duplicate_options_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal libpostal_duplicate_options_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(libpostal_duplicate_options_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~libpostal_duplicate_options_t() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          LibPostalPINVOKE.delete_libpostal_duplicate_options_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public uint num_languages {
    set {
      LibPostalPINVOKE.libpostal_duplicate_options_t_num_languages_set(swigCPtr, value);
    } 
    get {
      uint ret = LibPostalPINVOKE.libpostal_duplicate_options_t_num_languages_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_char languages {
    set {
      LibPostalPINVOKE.libpostal_duplicate_options_t_languages_set(swigCPtr, SWIGTYPE_p_p_char.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = LibPostalPINVOKE.libpostal_duplicate_options_t_languages_get(swigCPtr);
      SWIGTYPE_p_p_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_p_char(cPtr, false);
      return ret;
    } 
  }

  public libpostal_duplicate_options_t() : this(LibPostalPINVOKE.new_libpostal_duplicate_options_t(), true) {
  }

}