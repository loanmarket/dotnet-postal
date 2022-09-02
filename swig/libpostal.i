 %module LibPostal
 %{
 /* Includes the header in the wrapper code */
 #include "libpostal.h"
 %}

%typemap(csclassmodifiers) SWIGTYPE, SWIGTYPE *, SWIGTYPE &, SWIGTYPE &&, SWIGTYPE [], SWIGTYPE (CLASS::*) "internal class"
%typemap(csclassmodifiers) enum SWIGTYPE "internal enum"
%pragma(csharp) moduleclassmodifiers="internal class"

 /* Parse the header file to generate wrappers */
 %include "libpostal.h"
 /* Extend libpostal_address_parser_response to provide access to char ** elements */
 %extend libpostal_address_parser_response {
    char * component_get(size_t index) {
        return $self->components[index];
    }

    char * label_get(size_t index) {
        return $self->labels[index];
    }
 };