using EKZAMENADONET.Models;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EKZAMENADONET.ViewModels
{
    class GoodDialogViewModal : BindableBase
    {
        private int goodId;
        private string goodTitle;
        private string producer;
        private string description;
        private byte[] picture = null;
        private int characteristicId;
        private int categoryId;
        private bool closeDialog;
        private string filename = "Upload the file";
        private ICommand saveCommand;
        private ICommand cancelCommand;
        private ICommand uploadImage;

        //get and set goodId
        public int GoodId
        {
            get => goodId;
            set => SetProperty(ref goodId, value);
        }
        public bool DialogResult { get; set; }

        //SaveCommand
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new DelegateCommand(
                    () =>
                    {
                        //Change a dialog value
                        DialogResult = true;
                        CloseDialog = true;
                    }
                    ));
            }
        }

        //CloseDialog
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new DelegateCommand(
                    () =>
                    {
                        DialogResult = false;
                        CloseDialog = true;
                    }));
            }
        }

        //get file name
        public string Filename
        {
            get => filename;
            set 
            { 
                if (SetProperty(ref filename, value)) 
                {
                    RaisePropertyChanged(nameof(filename));
                } 
            }
        }


        //upload image
        public ICommand UploadImage
        {
            get
            {
                return uploadImage ?? (uploadImage = new DelegateCommand<EventArgs>((e) =>
                {

                    //open dialog
                    OpenFileDialog dlg = new OpenFileDialog();
                    //filter
                    dlg.Filter = "JPEG|*.jpg";
                    dlg.Multiselect = false;
                    dlg.CheckFileExists = true;

                    //open dialog cancel
                    if (dlg.ShowDialog() != true)
                        return;  // return nothing
                    Filename = dlg.FileName; // get file name


                    ////**********************************************************************
                    //FileStream fs = new FileStream(Filename, FileMode.Open, FileAccess.Read);
                    //BinaryReader br = new BinaryReader(fs);
                    //long numBytes = new FileInfo(Filename).Length;
                    //Picture = br.ReadBytes((int)numBytes);

                    //Convert a string in byte
                    Picture = File.ReadAllBytes(dlg.FileName);
                }));
            }
        }


        public bool CloseDialog
        {
            get => closeDialog;
            set
            {
                if (closeDialog != value)
                {
                    closeDialog = value;
                    RaisePropertyChanged();
                }
            }
        }

        //GoodTitle
        public string GoodTitle
        {
            get => goodTitle;
            set
            {
                if (goodTitle != value)
                    SetProperty(ref goodTitle, value);
            }
        }
        //producer
        public string Producer
        {
            get => producer;
            set
            {
                if (producer != value)
                    SetProperty(ref producer, value);
            }
        }

        //Get collection of Categorie
        public ObservableCollection<Category> Categories
        {
            get
            {
                using (MagasineEntities db = new MagasineEntities())
                {
                    var c = new ObservableCollection<Category>(db.Categories);
                    return c;
                }
            }
        }

        //Get Collection of Characteristic
        public ObservableCollection<Characteristic> Characteristics
        {
            get
            {
                using (MagasineEntities db = new MagasineEntities())
                {
                    var c = new ObservableCollection<Characteristic>(db.Characteristics);
                    return c;
                }
            }
        }

        //Description
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                    SetProperty(ref description, value);
            }
        }

        //Picture in byte
        public byte[] Picture
        {
            get => picture;
            set
            {
                if (picture != value)
                    SetProperty(ref picture, value);
            }
        }

        //get and set CharacteristicId
        public int CharacteristicId
        {
            get => characteristicId;
            set
            {
                if (characteristicId != value)
                    SetProperty(ref characteristicId, value);
            }
        }

        //get and set CategoryId
        public int CategoryId
        {
            get => categoryId;
            set
            {
                if (categoryId != value)
                    SetProperty(ref categoryId, value);
            }
        }
    }
}
