
  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  4                          //saying that this method requires a stack of max 4
    .locals init (int32 V_0,              //declares i
             int32 V_1,                   // least
             int32 V_2,                   // j
             int32 V_3)                   // tmp
    IL_0000:  ldc.i4.0                    //pushes 0 to the stack as int32 (i value)
    IL_0001:  stloc.0                     //pops the top stack value into local variable 0
    IL_0002:  br.s       IL_0032          //branches to instruction 32

    IL_0004:  ldloc.0                     //load local variable 0 onto stack. 
    IL_0005:  stloc.1                     // least = i
    IL_0006:  ldloc.0                     // variable i
    IL_0007:  ldc.i4.1                    // push 1 to the stack
    IL_0008:  add                         //i+1
    IL_0009:  stloc.2                     //store in j
    IL_000a:  br.s       IL_001a          // branch to 001a

    IL_000c:  ldarg.0                     //load (arr) to stack
    IL_000d:  ldloc.2                     //load j
    IL_000e:  ldelem.i4                   // load element of arr at index j
    IL_000f:  ldarg.0                     //load arr
    IL_0010:  ldloc.1                     // load i
    IL_0011:  ldelem.i4                   // load element of arr at index i
    IL_0012:  bge.s      IL_0016          // compare the two elements (and possibly branch to 0016)

    IL_0014:  ldloc.2                     //load j
    IL_0015:  stloc.1                     // least = j
    IL_0016:  ldloc.2                     //load j
    IL_0017:  ldc.i4.1                    //push 1 onto the stack
    IL_0018:  add                         //j +1
    IL_0019:  stloc.2                     // store in j
    IL_001a:  ldloc.2                     // load j to stack
    IL_001b:  ldarg.0                     // load arr to stack
    IL_001c:  ldlen                       // push length
    IL_001d:  conv.i4                     // convert to int
    IL_001e:  blt.s      IL_000c          // compare the two, branch if true

    IL_0020:  ldarg.0                     //load arr
    IL_0021:  ldloc.0                     //load i
    IL_0022:  ldelem.i4                   // load element of arr at index i
    IL_0023:  stloc.3                     // store in tmp
    IL_0024:  ldarg.0                     //load arr
    IL_0025:  ldloc.0                     //load i
    IL_0026:  ldarg.0                     //load arr
    IL_0027:  ldloc.1                     //load leasr
    IL_0028:  ldelem.i4                   //load element in arr at index of least
    IL_0029:  stelem.i4                   // store that element at arr on index i
    IL_002a:  ldarg.0                     // load arr
    IL_002b:  ldloc.1                     // load leas
    IL_002c:  ldloc.3                     // load tmp
    IL_002d:  stelem.i4                   // arr[least] = tmp
    IL_002e:  ldloc.0                     // load i
    IL_002f:  ldc.i4.1                    // push 1 to stack
    IL_0030:  add                         // i +1
    IL_0031:  stloc.0                     // store that in i
    IL_0032:  ldloc.0                   // load the value from variable 0 to top of the stack
    IL_0033:  ldarg.0                   // load argument (arr) onto the stack
    IL_0034:  ldlen                     // push lenght of the array to the stack
    IL_0035:  conv.i4                   // convert to integer
    IL_0036:  blt.s      IL_0004        //compares the two (if i is still smaller than array length go to
                                        // instruction 0004
    IL_0038:  ret                       //else return
  } // end of method Selsort::SelectionSort
