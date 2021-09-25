.class public auto ansi beforefieldinit
  CalculatorIL.InputParser
    extends System.Object
{
  .field public static literal int32 AllCorrect = int32(0) // 0x00000000

  .field public static literal int32 WrongArgs = int32(1) // 0x00000001

  .field public static literal int32 WrongOperation = int32(2) // 0x00000002

  .field public static literal int32 WrongArgsCount = int32(3) // 0x00000003

  .field public static literal int32 DivideByZero = int32(4) // 0x00000004

  .method public hidebysig static int32
    TryParseArguments(
      string[] args,
      [out] int32& val1,
      [out] valuetype CalculatorIL.Calculator/Operation& operation,
      [out] int32& val2
    ) cil managed
  {
    .maxstack 5
    .locals init (
      [0] bool V_0,
      [1] int32 V_1,
      [2] bool V_2,
      [3] bool V_3,
      [4] bool V_4
    )
    ldarg.1      // val1
    ldc.i4.0
    stind.i4

    ldarg.2      // operation
    ldc.i4.0
    stind.i4

    ldarg.3      // val2
    ldc.i4.0
    stind.i4

    ldarg.0      // args
    call         bool CalculatorIL.InputParser::CheckArgsCount(string[])
    ldc.i4.0
    ceq
    stloc.0      // V_0

    ldloc.0      // V_0
    brfalse.s    IL_001e

    ldc.i4.3
    stloc.1      // V_1
    br           IL_00ab

    IL_001e: ldarg.0      // args
    ldc.i4.1
    ldelem.ref
    ldarg.2      // operation
    call         bool CalculatorIL.InputParser::TryParseOperation(string, valuetype CalculatorIL.Calculator/Operation&)
    ldc.i4.0
    ceq
    stloc.2      // V_2

    ldloc.2      // V_2
    brfalse.s    IL_0032

    ldc.i4.2
    stloc.1      // V_1
    br.s         IL_00ab

    IL_0032: ldarg.0      // args
    ldc.i4.0
    ldelem.ref
    ldarg.1      // val1
    call         bool CalculatorIL.InputParser::TryParseValue(string, int32&)
    brfalse.s    IL_004b
    IL_003d: ldarg.0      // args
    ldc.i4.2
    ldelem.ref
    ldarg.3      // val2
    call         bool CalculatorIL.InputParser::TryParseValue(string, int32&)
    ldc.i4.0
    ceq
    br.s         IL_004c
    IL_004b: ldc.i4.1
    IL_004c: stloc.3      // V_3

    ldloc.3      // V_3
    brfalse.s    IL_0054

    ldc.i4.1
    stloc.1      // V_1
    br.s         IL_00ab

    IL_0054: ldarg.2      // operation
    ldind.i4
    ldc.i4.3
    bne.un.s     IL_0060
    ldarg.3      // val2
    ldind.i4
    ldc.i4.0
    ceq
    br.s         IL_0061
    IL_0060: ldc.i4.0
    IL_0061: stloc.s      V_4

    ldloc.s      V_4
    brfalse.s    IL_00a7

    ldc.i4.6
    newarr       [System.Runtime]System.String
    dup
    ldc.i4.0
    ldarg.0      // args
    ldc.i4.0
    ldelem.ref
    stelem.ref
    dup
    ldc.i4.1
    ldstr        " "
    stelem.ref
    dup
    ldc.i4.2
    ldarg.0      // args
    ldc.i4.1
    ldelem.ref
    stelem.ref
    dup
    ldc.i4.3
    ldstr        " "
    stelem.ref
    dup
    ldc.i4.4
    ldarg.0      // args
    ldc.i4.2
    ldelem.ref
    stelem.ref
    dup
    ldc.i4.5
    ldstr        " division by zero error!"
    stelem.ref
    call         string [System.Runtime]System.String::Concat(string[])
    call         void [System.Console]System.Console::WriteLine(string)
    

    
    ldc.i4.4
    stloc.1      // V_1
    br.s         IL_00ab

    
    IL_00a7: ldc.i4.0
    stloc.1      // V_1
    br.s         IL_00ab

    IL_00ab: ldloc.1      // V_1
    ret

  }

  .method private hidebysig static bool
    CheckArgsCount(
      string[] args
    ) cil managed
  {
    .maxstack 2

    ldarg.0      // args
    ldlen
    conv.i4
    ldc.i4.3
    ceq
    brfalse.s incorrect
    ldc.i4.1
    ret
    
    incorrect: ldstr "The calculator requires 3 arguments, but {0} provided"
    ldarg.0
    ldlen
    conv.i4
    box          [System.Runtime]System.Int32
    call         string [System.Runtime]System.String::Format(string, object)
    call         void [System.Console]System.Console::WriteLine(string)
    ldc.i4.0
    ret
  }

  .method private hidebysig static bool
    TryParseOperation(
      string op,
      [out] valuetype CalculatorIL.Calculator/Operation& operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 numberOperation
    )
    
    ldarg.0
    ldstr        "+"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Plus
    ldarg.0
    ldstr        "-"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Minus
    ldarg.0
    ldstr        "*"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Multiply
    ldarg.0
    ldstr        "/"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Divide
    br.s         Incorrect

    Plus: ldc.i4.0
    stloc.0
    br.s Asign

    Minus: ldc.i4.1
    stloc.0
    br.s Asign

    Multiply: ldc.i4.2
    stloc.0
    br.s Asign

    Divide: ldc.i4.3
    stloc.0
    br.s Asign

    Incorrect: ldc.i4.4
    stloc.0

    Asign:ldarg.1
    ldloc.0
    stind.i4

    ldarg.1
    ldind.i4
    ldc.i4.4
    ceq
    brtrue.s unsupported

    supported:
    ldc.i4.1
    ret

    unsupported:
    ldstr "Unsupported operation received: "
    ldarg.0
    call string [System.Runtime]System.String::Concat(string, string)
    call void [System.Console]System.Console::WriteLine(string)
    ldc.i4.0
    ret
  }

  .method private hidebysig static bool
    TryParseValue(
      string arg,
      [out] int32& val
    ) cil managed
  {
    .maxstack 2

    ldarg.0
    ldarg.1
    call bool [System.Runtime]System.Int32::TryParse(string, int32&)
    brtrue.s    isVal

    isNotVal: ldstr "Value is not int: "
    ldarg.0
    call string [System.Runtime]System.String::Concat(string, string)
    call void [System.Console]System.Console::WriteLine(string)
    ldc.i4.0
    ret

    isVal: ldc.i4.1      // isVal
    ret
  }
} 
