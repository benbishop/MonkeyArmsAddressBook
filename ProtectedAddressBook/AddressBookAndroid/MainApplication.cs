using System;
using Android.App;
using MonkeyArms.LockedAddressBook.Core.Config;
using MonkeyArms.LockedAddressBook.Delegates;
using MonkeyArms.LockedAddressBook.Core.Commands;
using Android.Runtime;

namespace MonkeyArms.LockedAddressBook.Android
{
	[Application]
	class MainApplication:Application
	{


		public MainApplication (IntPtr handle, JniHandleOwnership transfer)
			: base (handle, transfer)
		{
			BaseAppContext.Init();

			//platform specific mappings
			DI.MapClassToInterface<GetContactsDelegate, IGetContactsDelegate> ();


		
		}

		public override void OnCreate ()
		{
			base.OnCreate ();
		}
	}
}

