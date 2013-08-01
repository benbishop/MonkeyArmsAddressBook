using System;
using MonkeyArms.LockedAddressBook.Core.ViewModels;
using MonkeyArms.LockedAddressBook.Core.Commands;
using MonkeyArms.LockedAddressBook.Core.Invokers;
using MonkeyArms.LockedAddressBook.Core.Mediators;
using MonkeyArms.LockedAddressBook.Core.Views;

namespace MonkeyArms.LockedAddressBook.Core.Config
{
	public static class BaseAppContext
	{
		public static void Init()
		{
			//View Models
			DI.MapSingleton<ContactDetailsViewModel>();
			DI.MapSingleton<ContactsListViewModel> ();

			//Invoker/Command mappings
			DI.MapCommandToInvoker<GetContactsCommand, GetContactsInvoker> ();
			DI.MapCommandToInvoker<SetSelectedContactCommand, SetSelectedContactInvoker> ();

			//Interface/Mediator mappings
			DI.MapMediatorToClass<ContactDetailsViewMediator, IContactDetailsView> ();
			DI.MapMediatorToClass<ContactsListViewMediator, IContactsListView> ();
			DI.MapMediatorToClass<PasswordViewMediator, IPasswordView> ();
		}
	}
}

