; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [192 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 46
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 75
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 9
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 70
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 60
	i32 120558881, ; 5: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 60
	i32 165246403, ; 6: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 27
	i32 182336117, ; 7: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 61
	i32 209399409, ; 8: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 25
	i32 230216969, ; 9: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 41
	i32 231814094, ; 10: System.Globalization => 0xdd133ce => 92
	i32 232815796, ; 11: System.Web.Services => 0xde07cb4 => 87
	i32 261689757, ; 12: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 30
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 45
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 39
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 17
	i32 321597661, ; 16: System.Numerics => 0x132b30dd => 12
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 43
	i32 441335492, ; 18: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 29
	i32 442521989, ; 19: Xamarin.Essentials => 0x1a605985 => 69
	i32 442565967, ; 20: System.Collections => 0x1a61054f => 89
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 38
	i32 465846621, ; 22: mscorlib => 0x1bc4415d => 8
	i32 469710990, ; 23: System.dll => 0x1bff388e => 11
	i32 476646585, ; 24: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 39
	i32 486930444, ; 25: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 50
	i32 498788369, ; 26: System.ObjectModel => 0x1dbae811 => 90
	i32 526420162, ; 27: System.Transactions.dll => 0x1f6088c2 => 81
	i32 545304856, ; 28: System.Runtime.Extensions => 0x2080b118 => 94
	i32 605376203, ; 29: System.IO.Compression.FileSystem => 0x24154ecb => 85
	i32 627609679, ; 30: Xamarin.AndroidX.CustomView => 0x2568904f => 34
	i32 663517072, ; 31: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 66
	i32 666292255, ; 32: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 22
	i32 690569205, ; 33: System.Xml.Linq.dll => 0x29293ff5 => 16
	i32 700030136, ; 34: AlbertSessionFour.Android.dll => 0x29b99cb8 => 0
	i32 775507847, ; 35: System.IO.Compression => 0x2e394f87 => 84
	i32 809851609, ; 36: System.Drawing.Common.dll => 0x30455ad9 => 83
	i32 843511501, ; 37: Xamarin.AndroidX.Print => 0x3246f6cd => 57
	i32 877678880, ; 38: System.Globalization.dll => 0x34505120 => 92
	i32 928116545, ; 39: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 75
	i32 955402788, ; 40: Newtonsoft.Json => 0x38f24a24 => 9
	i32 967690846, ; 41: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 43
	i32 974778368, ; 42: FormsViewGroup.dll => 0x3a19f000 => 5
	i32 992768348, ; 43: System.Collections.dll => 0x3b2c715c => 89
	i32 1012816738, ; 44: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 59
	i32 1035644815, ; 45: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 21
	i32 1042160112, ; 46: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 72
	i32 1052210849, ; 47: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 47
	i32 1098259244, ; 48: System => 0x41761b2c => 11
	i32 1175144683, ; 49: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 64
	i32 1178241025, ; 50: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 54
	i32 1204270330, ; 51: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 22
	i32 1267360935, ; 52: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 65
	i32 1293217323, ; 53: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 36
	i32 1324164729, ; 54: System.Linq => 0x4eed2679 => 95
	i32 1365406463, ; 55: System.ServiceModel.Internals.dll => 0x516272ff => 78
	i32 1376866003, ; 56: Xamarin.AndroidX.SavedState => 0x52114ed3 => 59
	i32 1379779777, ; 57: System.Resources.ResourceManager => 0x523dc4c1 => 3
	i32 1395857551, ; 58: Xamarin.AndroidX.Media.dll => 0x5333188f => 51
	i32 1406073936, ; 59: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 31
	i32 1457743152, ; 60: System.Runtime.Extensions.dll => 0x56e36530 => 94
	i32 1460219004, ; 61: Xamarin.Forms.Xaml => 0x57092c7c => 73
	i32 1462112819, ; 62: System.IO.Compression.dll => 0x57261233 => 84
	i32 1469204771, ; 63: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 20
	i32 1556261602, ; 64: AlbertSessionFour.Android => 0x5cc2aae2 => 0
	i32 1582372066, ; 65: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 35
	i32 1592978981, ; 66: System.Runtime.Serialization.dll => 0x5ef2ee25 => 2
	i32 1622152042, ; 67: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 49
	i32 1624863272, ; 68: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 68
	i32 1636350590, ; 69: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 33
	i32 1639515021, ; 70: System.Net.Http.dll => 0x61b9038d => 1
	i32 1657153582, ; 71: System.Runtime => 0x62c6282e => 14
	i32 1658241508, ; 72: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 62
	i32 1658251792, ; 73: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 74
	i32 1670060433, ; 74: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 30
	i32 1729485958, ; 75: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 26
	i32 1766324549, ; 76: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 61
	i32 1776026572, ; 77: System.Core.dll => 0x69dc03cc => 10
	i32 1788241197, ; 78: Xamarin.AndroidX.Fragment => 0x6a96652d => 38
	i32 1808609942, ; 79: Xamarin.AndroidX.Loader => 0x6bcd3296 => 49
	i32 1813201214, ; 80: Xamarin.Google.Android.Material => 0x6c13413e => 74
	i32 1818569960, ; 81: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 55
	i32 1867746548, ; 82: Xamarin.Essentials.dll => 0x6f538cf4 => 69
	i32 1878053835, ; 83: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 73
	i32 1885316902, ; 84: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 23
	i32 1900610850, ; 85: System.Resources.ResourceManager.dll => 0x71490522 => 3
	i32 1919157823, ; 86: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 52
	i32 2019465201, ; 87: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 47
	i32 2055257422, ; 88: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 44
	i32 2079903147, ; 89: System.Runtime.dll => 0x7bf8cdab => 14
	i32 2090596640, ; 90: System.Numerics.Vectors => 0x7c9bf920 => 13
	i32 2097448633, ; 91: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 40
	i32 2126786730, ; 92: Xamarin.Forms.Platform.Android => 0x7ec430aa => 71
	i32 2193016926, ; 93: System.ObjectModel.dll => 0x82b6c85e => 90
	i32 2201231467, ; 94: System.Net.Http => 0x8334206b => 1
	i32 2217644978, ; 95: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 64
	i32 2244775296, ; 96: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 50
	i32 2256548716, ; 97: Xamarin.AndroidX.MultiDex => 0x8680336c => 52
	i32 2261435625, ; 98: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 42
	i32 2279755925, ; 99: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 58
	i32 2315684594, ; 100: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 18
	i32 2373047941, ; 101: XamForms.Controls.Calendar.Droid => 0x8d71d685 => 77
	i32 2409053734, ; 102: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 56
	i32 2465532216, ; 103: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 29
	i32 2471841756, ; 104: netstandard.dll => 0x93554fdc => 79
	i32 2475788418, ; 105: Java.Interop.dll => 0x93918882 => 6
	i32 2501346920, ; 106: System.Data.DataSetExtensions => 0x95178668 => 82
	i32 2505896520, ; 107: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 46
	i32 2581819634, ; 108: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 65
	i32 2620871830, ; 109: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 33
	i32 2624644809, ; 110: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 37
	i32 2633051222, ; 111: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 45
	i32 2701096212, ; 112: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 62
	i32 2715334215, ; 113: System.Threading.Tasks.dll => 0xa1d8b647 => 91
	i32 2732626843, ; 114: Xamarin.AndroidX.Activity => 0xa2e0939b => 17
	i32 2737747696, ; 115: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 20
	i32 2766581644, ; 116: Xamarin.Forms.Core => 0xa4e6af8c => 70
	i32 2778768386, ; 117: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 67
	i32 2810250172, ; 118: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 31
	i32 2819470561, ; 119: System.Xml.dll => 0xa80db4e1 => 15
	i32 2853208004, ; 120: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 67
	i32 2855708567, ; 121: Xamarin.AndroidX.Transition => 0xaa36a797 => 63
	i32 2903344695, ; 122: System.ComponentModel.Composition => 0xad0d8637 => 86
	i32 2905242038, ; 123: mscorlib.dll => 0xad2a79b6 => 8
	i32 2916838712, ; 124: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 68
	i32 2919462931, ; 125: System.Numerics.Vectors.dll => 0xae037813 => 13
	i32 2921128767, ; 126: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 19
	i32 2978675010, ; 127: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 36
	i32 3024354802, ; 128: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 41
	i32 3044182254, ; 129: FormsViewGroup => 0xb57288ee => 5
	i32 3057625584, ; 130: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 53
	i32 3075834255, ; 131: System.Threading.Tasks => 0xb755818f => 91
	i32 3111772706, ; 132: System.Runtime.Serialization => 0xb979e222 => 2
	i32 3204380047, ; 133: System.Data.dll => 0xbefef58f => 80
	i32 3211777861, ; 134: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 35
	i32 3220365878, ; 135: System.Threading => 0xbff2e236 => 93
	i32 3247949154, ; 136: Mono.Security => 0xc197c562 => 88
	i32 3258312781, ; 137: Xamarin.AndroidX.CardView => 0xc235e84d => 26
	i32 3267021929, ; 138: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 24
	i32 3317135071, ; 139: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 34
	i32 3317144872, ; 140: System.Data => 0xc5b79d28 => 80
	i32 3340431453, ; 141: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 23
	i32 3346324047, ; 142: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 54
	i32 3353484488, ; 143: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 40
	i32 3362522851, ; 144: Xamarin.AndroidX.Core => 0xc86c06e3 => 32
	i32 3366347497, ; 145: Java.Interop => 0xc8a662e9 => 6
	i32 3374999561, ; 146: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 58
	i32 3404865022, ; 147: System.ServiceModel.Internals => 0xcaf21dfe => 78
	i32 3429136800, ; 148: System.Xml => 0xcc6479a0 => 15
	i32 3430777524, ; 149: netstandard => 0xcc7d82b4 => 79
	i32 3441283291, ; 150: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 37
	i32 3476120550, ; 151: Mono.Android => 0xcf3163e6 => 7
	i32 3486566296, ; 152: System.Transactions => 0xcfd0c798 => 81
	i32 3493954962, ; 153: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 28
	i32 3501239056, ; 154: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 24
	i32 3509114376, ; 155: System.Xml.Linq => 0xd128d608 => 16
	i32 3536029504, ; 156: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 71
	i32 3567349600, ; 157: System.ComponentModel.Composition.dll => 0xd4a16f60 => 86
	i32 3586971312, ; 158: XamForms.Controls.Calendar.Droid.dll => 0xd5ccd6b0 => 77
	i32 3608519521, ; 159: System.Linq.dll => 0xd715a361 => 95
	i32 3618140916, ; 160: Xamarin.AndroidX.Preference => 0xd7a872f4 => 56
	i32 3627220390, ; 161: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 57
	i32 3632359727, ; 162: Xamarin.Forms.Platform => 0xd881692f => 72
	i32 3633644679, ; 163: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 19
	i32 3641597786, ; 164: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 44
	i32 3672681054, ; 165: Mono.Android.dll => 0xdae8aa5e => 7
	i32 3676310014, ; 166: System.Web.Services.dll => 0xdb2009fe => 87
	i32 3682565725, ; 167: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 25
	i32 3684561358, ; 168: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 28
	i32 3689375977, ; 169: System.Drawing.Common => 0xdbe768e9 => 83
	i32 3718780102, ; 170: Xamarin.AndroidX.Annotation => 0xdda814c6 => 18
	i32 3724971120, ; 171: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 53
	i32 3758932259, ; 172: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 42
	i32 3786282454, ; 173: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 27
	i32 3822602673, ; 174: Xamarin.AndroidX.Media => 0xe3d849b1 => 51
	i32 3829621856, ; 175: System.Numerics.dll => 0xe4436460 => 12
	i32 3885922214, ; 176: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 63
	i32 3896760992, ; 177: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 32
	i32 3920810846, ; 178: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 85
	i32 3920836241, ; 179: AlbertSessionFour.dll => 0xe9b33691 => 4
	i32 3921031405, ; 180: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 66
	i32 3931092270, ; 181: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 55
	i32 3945713374, ; 182: System.Data.DataSetExtensions.dll => 0xeb2ecede => 82
	i32 3955647286, ; 183: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 21
	i32 4014908255, ; 184: XamForms.Controls.Calendar => 0xef4ea35f => 76
	i32 4015340408, ; 185: AlbertSessionFour => 0xef553b78 => 4
	i32 4073602200, ; 186: System.Threading.dll => 0xf2ce3c98 => 93
	i32 4105002889, ; 187: Mono.Security.dll => 0xf4ad5f89 => 88
	i32 4151237749, ; 188: System.Core => 0xf76edc75 => 10
	i32 4182413190, ; 189: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 48
	i32 4220811361, ; 190: XamForms.Controls.Calendar.dll => 0xfb947861 => 76
	i32 4292120959 ; 191: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 48
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [192 x i32] [
	i32 46, i32 75, i32 9, i32 70, i32 60, i32 60, i32 27, i32 61, ; 0..7
	i32 25, i32 41, i32 92, i32 87, i32 30, i32 45, i32 39, i32 17, ; 8..15
	i32 12, i32 43, i32 29, i32 69, i32 89, i32 38, i32 8, i32 11, ; 16..23
	i32 39, i32 50, i32 90, i32 81, i32 94, i32 85, i32 34, i32 66, ; 24..31
	i32 22, i32 16, i32 0, i32 84, i32 83, i32 57, i32 92, i32 75, ; 32..39
	i32 9, i32 43, i32 5, i32 89, i32 59, i32 21, i32 72, i32 47, ; 40..47
	i32 11, i32 64, i32 54, i32 22, i32 65, i32 36, i32 95, i32 78, ; 48..55
	i32 59, i32 3, i32 51, i32 31, i32 94, i32 73, i32 84, i32 20, ; 56..63
	i32 0, i32 35, i32 2, i32 49, i32 68, i32 33, i32 1, i32 14, ; 64..71
	i32 62, i32 74, i32 30, i32 26, i32 61, i32 10, i32 38, i32 49, ; 72..79
	i32 74, i32 55, i32 69, i32 73, i32 23, i32 3, i32 52, i32 47, ; 80..87
	i32 44, i32 14, i32 13, i32 40, i32 71, i32 90, i32 1, i32 64, ; 88..95
	i32 50, i32 52, i32 42, i32 58, i32 18, i32 77, i32 56, i32 29, ; 96..103
	i32 79, i32 6, i32 82, i32 46, i32 65, i32 33, i32 37, i32 45, ; 104..111
	i32 62, i32 91, i32 17, i32 20, i32 70, i32 67, i32 31, i32 15, ; 112..119
	i32 67, i32 63, i32 86, i32 8, i32 68, i32 13, i32 19, i32 36, ; 120..127
	i32 41, i32 5, i32 53, i32 91, i32 2, i32 80, i32 35, i32 93, ; 128..135
	i32 88, i32 26, i32 24, i32 34, i32 80, i32 23, i32 54, i32 40, ; 136..143
	i32 32, i32 6, i32 58, i32 78, i32 15, i32 79, i32 37, i32 7, ; 144..151
	i32 81, i32 28, i32 24, i32 16, i32 71, i32 86, i32 77, i32 95, ; 152..159
	i32 56, i32 57, i32 72, i32 19, i32 44, i32 7, i32 87, i32 25, ; 160..167
	i32 28, i32 83, i32 18, i32 53, i32 42, i32 27, i32 51, i32 12, ; 168..175
	i32 63, i32 32, i32 85, i32 4, i32 66, i32 55, i32 82, i32 21, ; 176..183
	i32 76, i32 4, i32 93, i32 88, i32 10, i32 48, i32 76, i32 48 ; 192..191
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
