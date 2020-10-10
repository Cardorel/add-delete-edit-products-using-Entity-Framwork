using EKZAMENADONET.Dialogs;
using EKZAMENADONET.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EKZAMENADONET.ViewModels
{
    public class GoodViewModel : BindableBase, IGood
    {
        private ICommand editCommand;
        private ICommand deleteCommand;
        private ICommand addCommand;
        private Good selectedItem;
        private string filter;
        public GoodViewModel() { }

        /// <summary>
        /// get and set a string filter
        /// </summary>
        public string Filter
        {
            get => filter;
            set
            {
                if (SetProperty(ref filter, value))
                {
                    RaisePropertyChanged(nameof(Goods));
                }
            }
        }

        /// <summary>
        /// A collection of all Goods in Data base
        /// </summary>
        public ObservableCollection<Good> Goods
        {
            get
            {
                using (MagasineEntities db = new MagasineEntities())
                {
                    //check if a user doesnt tape anything
                    if (!string.IsNullOrEmpty(filter))
                    {
                        //get the collection of the filter in good
                        var f = from p in db.Goods where p.goodTitle.Contains(filter) select p;
                        return new ObservableCollection<Good>(f);  //Return new collection

                    }

                    return new ObservableCollection<Good>(db.Goods);  //collection in database
                }
            }
        }
        /// <summary>
        /// get and set a value for the selected item
        /// </summary>
        public Good SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        /// <summary>
        /// Command to delete any item selected in data grid
        /// </summary>
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new DelegateCommand<RoutedEventArgs>((e) =>
                {
                    if (selectedItem != null)
                    {
                        ///Open the Entity
                        using (MagasineEntities db = new MagasineEntities())
                        {
                            //use Attach for repopulate a context that we selected
                            db.Goods.Attach(selectedItem);
                            //For given the Entity about the status
                            db.Entry(selectedItem).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();
                            RaisePropertyChanged(nameof(Goods));
                        }
                    }
                }));
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new DelegateCommand(() =>
                {
                    var vm = new GoodDialogViewModal();
                    DialogFactory.ShowGoodDialog(vm);
                    if (vm.DialogResult)
                    {
                        using (MagasineEntities db = new MagasineEntities())
                        {
                            if (
                               !string.IsNullOrWhiteSpace(vm.GoodTitle) ||
                               !string.IsNullOrWhiteSpace(vm.GoodTitle) ||
                               !string.IsNullOrWhiteSpace(vm.Producer)  ||
                               !string.IsNullOrWhiteSpace(vm.Description)
                               )
                            {
                                db.Goods.Add(new Good()
                                {
                                   
                                    goodTitle = vm.GoodTitle,
                                    producer = vm.Producer,
                                    description = vm.Description,
                                    photo = vm.Picture,
                                    characteristicId = Convert.ToInt32(vm.CharacteristicId),
                                    categoryId = Convert.ToInt32(vm.CategoryId)
                                });
                            }

                            db.SaveChanges();
                            RaisePropertyChanged(nameof(Goods));
                            MessageBox.Show("Added in Data base", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        vm.GoodTitle = string.Empty;
                        vm.Producer = string.Empty;
                        vm.Description = string.Empty;
                        vm.CharacteristicId = -1;
                        vm.CategoryId = -1;
                    }

                }));
            }
        }



        /// <summary>
        /// Edit Command
        /// </summary>
        public ICommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = new DelegateCommand<RoutedEventArgs>(
                (e) =>
                {
                    if (selectedItem != null)
                    {
                        var vm = new GoodDialogViewModal()
                        {
                            GoodId = SelectedItem.goodId,
                            GoodTitle = SelectedItem.goodTitle,
                            Producer = SelectedItem.producer,
                            Description = SelectedItem.description,
                            CategoryId = SelectedItem.categoryId,
                            CharacteristicId = SelectedItem.characteristicId,
                            Picture = SelectedItem.photo
                        };
                       

                        DialogFactory.ShowGoodDialog(vm);
                        if (vm.DialogResult)
                        {
                            var goodAttach = new Good()
                            {
                                goodId = vm.GoodId,
                                goodTitle = vm.GoodTitle,
                                producer = vm.Producer,
                                description = vm.Description,
                                photo = vm.Picture,
                                characteristicId = vm.CharacteristicId,
                                categoryId = vm.CategoryId
                            };

                            using (MagasineEntities db = new MagasineEntities())
                            {
                                                              
                                db.Goods.Attach(goodAttach);
                                db.Entry(goodAttach).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                                RaisePropertyChanged(nameof(Goods));
                            }
                        }
                    }
                }));
            }
        }
    }
}
