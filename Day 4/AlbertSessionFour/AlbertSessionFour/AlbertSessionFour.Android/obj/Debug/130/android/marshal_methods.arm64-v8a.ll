; ModuleID = 'obj\Debug\130\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [192 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 37
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 7
	i64 210515253464952879, ; 2: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 27
	i64 232391251801502327, ; 3: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 59
	i64 295915112840604065, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 60
	i64 634308326490598313, ; 5: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 46
	i64 702024105029695270, ; 6: System.Drawing.Common => 0x9be17343c0e7726 => 83
	i64 720058930071658100, ; 7: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 40
	i64 872800313462103108, ; 8: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 36
	i64 940822596282819491, ; 9: System.Transactions => 0xd0e792aa81923a3 => 81
	i64 996343623809489702, ; 10: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 72
	i64 1000557547492888992, ; 11: Mono.Security.dll => 0xde2b1c9cba651a0 => 88
	i64 1120440138749646132, ; 12: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 74
	i64 1315114680217950157, ; 13: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 22
	i64 1425944114962822056, ; 14: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 2
	i64 1624659445732251991, ; 15: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 20
	i64 1628611045998245443, ; 16: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 48
	i64 1636321030536304333, ; 17: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 41
	i64 1731380447121279447, ; 18: Newtonsoft.Json => 0x18071957e9b889d7 => 9
	i64 1795316252682057001, ; 19: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 21
	i64 1836611346387731153, ; 20: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 59
	i64 1875917498431009007, ; 21: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 18
	i64 1981742497975770890, ; 22: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 47
	i64 2133195048986300728, ; 23: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 9
	i64 2136356949452311481, ; 24: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 52
	i64 2165725771938924357, ; 25: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 25
	i64 2262844636196693701, ; 26: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 36
	i64 2284400282711631002, ; 27: System.Web.Services => 0x1fb3d1f42fd4249a => 87
	i64 2329709569556905518, ; 28: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 44
	i64 2470498323731680442, ; 29: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 31
	i64 2479423007379663237, ; 30: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 64
	i64 2497223385847772520, ; 31: System.Runtime => 0x22a7eb7046413568 => 14
	i64 2547086958574651984, ; 32: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 17
	i64 2592350477072141967, ; 33: System.Xml.dll => 0x23f9e10627330e8f => 15
	i64 2624866290265602282, ; 34: mscorlib.dll => 0x246d65fbde2db8ea => 8
	i64 2694427813909235223, ; 35: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 56
	i64 2960931600190307745, ; 36: Xamarin.Forms.Core => 0x2917579a49927da1 => 70
	i64 2973416776963745376, ; 37: XamForms.Controls.Calendar.dll => 0x2943b2ce081c6660 => 76
	i64 3017704767998173186, ; 38: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 74
	i64 3289520064315143713, ; 39: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 43
	i64 3303437397778967116, ; 40: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 19
	i64 3311221304742556517, ; 41: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 13
	i64 3493805808809882663, ; 42: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 62
	i64 3522470458906976663, ; 43: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 61
	i64 3531994851595924923, ; 44: System.Numerics => 0x31042a9aade235bb => 12
	i64 3571415421602489686, ; 45: System.Runtime.dll => 0x319037675df7e556 => 14
	i64 3716579019761409177, ; 46: netstandard.dll => 0x3393f0ed5c8c5c99 => 79
	i64 3727469159507183293, ; 47: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 58
	i64 3772598417116884899, ; 48: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 37
	i64 4525561845656915374, ; 49: System.ServiceModel.Internals => 0x3ece06856b710dae => 78
	i64 4636684751163556186, ; 50: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 66
	i64 4782108999019072045, ; 51: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 24
	i64 4794310189461587505, ; 52: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 17
	i64 4795410492532947900, ; 53: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 61
	i64 4866169030951965436, ; 54: AlbertSessionFour => 0x43881af39ae612fc => 4
	i64 5081566143765835342, ; 55: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 3
	i64 5099468265966638712, ; 56: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 3
	i64 5142919913060024034, ; 57: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 71
	i64 5203618020066742981, ; 58: Xamarin.Essentials => 0x4836f704f0e652c5 => 69
	i64 5205316157927637098, ; 59: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 50
	i64 5348796042099802469, ; 60: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 51
	i64 5376510917114486089, ; 61: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 64
	i64 5399787500288379860, ; 62: AlbertSessionFour.dll => 0x4aefe61f49488bd4 => 4
	i64 5408338804355907810, ; 63: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 63
	i64 5451019430259338467, ; 64: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 30
	i64 5507995362134886206, ; 65: System.Core.dll => 0x4c705499688c873e => 10
	i64 5692067934154308417, ; 66: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 68
	i64 5757522595884336624, ; 67: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 28
	i64 5814345312393086621, ; 68: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 56
	i64 5896680224035167651, ; 69: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 45
	i64 6085203216496545422, ; 70: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 72
	i64 6086316965293125504, ; 71: FormsViewGroup.dll => 0x5476f10882baef80 => 5
	i64 6319713645133255417, ; 72: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 46
	i64 6401687960814735282, ; 73: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 44
	i64 6504860066809920875, ; 74: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 25
	i64 6548213210057960872, ; 75: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 34
	i64 6591024623626361694, ; 76: System.Web.Services.dll => 0x5b7805f9751a1b5e => 87
	i64 6659513131007730089, ; 77: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 40
	i64 6876862101832370452, ; 78: System.Xml.Linq => 0x5f6f85a57d108914 => 16
	i64 6894844156784520562, ; 79: System.Numerics.Vectors => 0x5faf683aead1ad72 => 13
	i64 7036436454368433159, ; 80: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 42
	i64 7103753931438454322, ; 81: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 39
	i64 7204980051946441770, ; 82: XamForms.Controls.Calendar => 0x63fd3b2f020b0c2a => 76
	i64 7270811800166795866, ; 83: System.Linq => 0x64e71ccf51a90a5a => 95
	i64 7488575175965059935, ; 84: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 16
	i64 7489048572193775167, ; 85: System.ObjectModel => 0x67ee71ff6b419e3f => 90
	i64 7635363394907363464, ; 86: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 70
	i64 7637365915383206639, ; 87: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 69
	i64 7654504624184590948, ; 88: System.Net.Http => 0x6a3a4366801b8264 => 1
	i64 7820441508502274321, ; 89: System.Data => 0x6c87ca1e14ff8111 => 80
	i64 7836164640616011524, ; 90: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 20
	i64 8044118961405839122, ; 91: System.ComponentModel.Composition => 0x6fa2739369944712 => 86
	i64 8064050204834738623, ; 92: System.Collections.dll => 0x6fe942efa61731bf => 89
	i64 8083354569033831015, ; 93: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 43
	i64 8103644804370223335, ; 94: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 82
	i64 8167236081217502503, ; 95: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 6
	i64 8185542183669246576, ; 96: System.Collections => 0x7198e33f4794aa70 => 89
	i64 8290740647658429042, ; 97: System.Runtime.Extensions => 0x730ea0b15c929a72 => 94
	i64 8398329775253868912, ; 98: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 29
	i64 8400357532724379117, ; 99: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 55
	i64 8601935802264776013, ; 100: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 63
	i64 8626175481042262068, ; 101: Java.Interop => 0x77b654e585b55834 => 6
	i64 8639588376636138208, ; 102: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 54
	i64 8684531736582871431, ; 103: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 85
	i64 9162065988803407493, ; 104: XamForms.Controls.Calendar.Droid.dll => 0x7f2632795f50ae85 => 77
	i64 9312692141327339315, ; 105: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 68
	i64 9324707631942237306, ; 106: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 21
	i64 9633879591279669694, ; 107: AlbertSessionFour.Android => 0x85b26a721f1c31be => 0
	i64 9662334977499516867, ; 108: System.Numerics.dll => 0x8617827802b0cfc3 => 12
	i64 9678050649315576968, ; 109: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 31
	i64 9711637524876806384, ; 110: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 51
	i64 9808709177481450983, ; 111: Mono.Android.dll => 0x881f890734e555e7 => 7
	i64 9825649861376906464, ; 112: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 28
	i64 9834056768316610435, ; 113: System.Transactions.dll => 0x8879968718899783 => 81
	i64 9998632235833408227, ; 114: Mono.Security => 0x8ac2470b209ebae3 => 88
	i64 10038780035334861115, ; 115: System.Net.Http.dll => 0x8b50e941206af13b => 1
	i64 10229024438826829339, ; 116: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 34
	i64 10376576884623852283, ; 117: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 62
	i64 10430153318873392755, ; 118: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 32
	i64 10566960649245365243, ; 119: System.Globalization.dll => 0x92a562b96dcd13fb => 92
	i64 10714184849103829812, ; 120: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 94
	i64 10847732767863316357, ; 121: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 22
	i64 11023048688141570732, ; 122: System.Core => 0x98f9bc61168392ac => 10
	i64 11037814507248023548, ; 123: System.Xml => 0x992e31d0412bf7fc => 15
	i64 11162124722117608902, ; 124: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 67
	i64 11340910727871153756, ; 125: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 33
	i64 11345533118204769135, ; 126: XamForms.Controls.Calendar.Droid => 0x9d736e428206736f => 77
	i64 11392833485892708388, ; 127: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 57
	i64 11529969570048099689, ; 128: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 67
	i64 11578238080964724296, ; 129: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 42
	i64 11580057168383206117, ; 130: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 18
	i64 11597940890313164233, ; 131: netstandard => 0xa0f429ca8d1805c9 => 79
	i64 11672361001936329215, ; 132: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 39
	i64 11743665907891708234, ; 133: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 91
	i64 12137774235383566651, ; 134: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 65
	i64 12451044538927396471, ; 135: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 38
	i64 12466513435562512481, ; 136: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 49
	i64 12487638416075308985, ; 137: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 35
	i64 12538491095302438457, ; 138: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 26
	i64 12550732019250633519, ; 139: System.IO.Compression => 0xae2d28465e8e1b2f => 84
	i64 12700543734426720211, ; 140: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 27
	i64 12963446364377008305, ; 141: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 83
	i64 13370592475155966277, ; 142: System.Runtime.Serialization => 0xb98de304062ea945 => 2
	i64 13401370062847626945, ; 143: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 65
	i64 13404347523447273790, ; 144: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 29
	i64 13454009404024712428, ; 145: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 75
	i64 13491513212026656886, ; 146: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 23
	i64 13572454107664307259, ; 147: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 58
	i64 13647894001087880694, ; 148: System.Data.dll => 0xbd670f48cb071df6 => 80
	i64 13959074834287824816, ; 149: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 38
	i64 13967638549803255703, ; 150: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 71
	i64 14124974489674258913, ; 151: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 26
	i64 14125464355221830302, ; 152: System.Threading.dll => 0xc407bafdbc707a9e => 93
	i64 14172845254133543601, ; 153: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 52
	i64 14261073672896646636, ; 154: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 57
	i64 14486659737292545672, ; 155: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 45
	i64 14644440854989303794, ; 156: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 50
	i64 14770906747976320980, ; 157: AlbertSessionFour.Android.dll => 0xccfccd6d7b8c87d4 => 0
	i64 14792063746108907174, ; 158: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 75
	i64 14852515768018889994, ; 159: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 33
	i64 14987728460634540364, ; 160: System.IO.Compression.dll => 0xcfff1ba06622494c => 84
	i64 14988210264188246988, ; 161: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 35
	i64 15076659072870671916, ; 162: System.ObjectModel.dll => 0xd13b0d8c1620662c => 90
	i64 15133485256822086103, ; 163: System.Linq.dll => 0xd204f0a9127dd9d7 => 95
	i64 15370334346939861994, ; 164: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 32
	i64 15582737692548360875, ; 165: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 48
	i64 15609085926864131306, ; 166: System.dll => 0xd89e9cf3334914ea => 11
	i64 15777549416145007739, ; 167: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 60
	i64 15810740023422282496, ; 168: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 73
	i64 15817206913877585035, ; 169: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 91
	i64 16154507427712707110, ; 170: System => 0xe03056ea4e39aa26 => 11
	i64 16565028646146589191, ; 171: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 86
	i64 16621146507174665210, ; 172: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 30
	i64 16677317093839702854, ; 173: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 55
	i64 16822611501064131242, ; 174: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 82
	i64 16833383113903931215, ; 175: mscorlib => 0xe99c30c1484d7f4f => 8
	i64 17024911836938395553, ; 176: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 19
	i64 17031351772568316411, ; 177: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 53
	i64 17037200463775726619, ; 178: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 41
	i64 17544493274320527064, ; 179: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 24
	i64 17627500474728259406, ; 180: System.Globalization => 0xf4a176498a351f4e => 92
	i64 17704177640604968747, ; 181: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 49
	i64 17710060891934109755, ; 182: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 47
	i64 17882897186074144999, ; 183: FormsViewGroup => 0xf82cd03e3ac830e7 => 5
	i64 17892495832318972303, ; 184: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 73
	i64 17928294245072900555, ; 185: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 85
	i64 18025913125965088385, ; 186: System.Threading => 0xfa28e87b91334681 => 93
	i64 18116111925905154859, ; 187: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 23
	i64 18121036031235206392, ; 188: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 53
	i64 18129453464017766560, ; 189: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 78
	i64 18305135509493619199, ; 190: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 54
	i64 18380184030268848184 ; 191: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 66
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [192 x i32] [
	i32 37, i32 7, i32 27, i32 59, i32 60, i32 46, i32 83, i32 40, ; 0..7
	i32 36, i32 81, i32 72, i32 88, i32 74, i32 22, i32 2, i32 20, ; 8..15
	i32 48, i32 41, i32 9, i32 21, i32 59, i32 18, i32 47, i32 9, ; 16..23
	i32 52, i32 25, i32 36, i32 87, i32 44, i32 31, i32 64, i32 14, ; 24..31
	i32 17, i32 15, i32 8, i32 56, i32 70, i32 76, i32 74, i32 43, ; 32..39
	i32 19, i32 13, i32 62, i32 61, i32 12, i32 14, i32 79, i32 58, ; 40..47
	i32 37, i32 78, i32 66, i32 24, i32 17, i32 61, i32 4, i32 3, ; 48..55
	i32 3, i32 71, i32 69, i32 50, i32 51, i32 64, i32 4, i32 63, ; 56..63
	i32 30, i32 10, i32 68, i32 28, i32 56, i32 45, i32 72, i32 5, ; 64..71
	i32 46, i32 44, i32 25, i32 34, i32 87, i32 40, i32 16, i32 13, ; 72..79
	i32 42, i32 39, i32 76, i32 95, i32 16, i32 90, i32 70, i32 69, ; 80..87
	i32 1, i32 80, i32 20, i32 86, i32 89, i32 43, i32 82, i32 6, ; 88..95
	i32 89, i32 94, i32 29, i32 55, i32 63, i32 6, i32 54, i32 85, ; 96..103
	i32 77, i32 68, i32 21, i32 0, i32 12, i32 31, i32 51, i32 7, ; 104..111
	i32 28, i32 81, i32 88, i32 1, i32 34, i32 62, i32 32, i32 92, ; 112..119
	i32 94, i32 22, i32 10, i32 15, i32 67, i32 33, i32 77, i32 57, ; 120..127
	i32 67, i32 42, i32 18, i32 79, i32 39, i32 91, i32 65, i32 38, ; 128..135
	i32 49, i32 35, i32 26, i32 84, i32 27, i32 83, i32 2, i32 65, ; 136..143
	i32 29, i32 75, i32 23, i32 58, i32 80, i32 38, i32 71, i32 26, ; 144..151
	i32 93, i32 52, i32 57, i32 45, i32 50, i32 0, i32 75, i32 33, ; 152..159
	i32 84, i32 35, i32 90, i32 95, i32 32, i32 48, i32 11, i32 60, ; 160..167
	i32 73, i32 91, i32 11, i32 86, i32 30, i32 55, i32 82, i32 8, ; 168..175
	i32 19, i32 53, i32 41, i32 24, i32 92, i32 49, i32 47, i32 5, ; 176..183
	i32 73, i32 85, i32 93, i32 23, i32 53, i32 78, i32 54, i32 66 ; 192..191
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
