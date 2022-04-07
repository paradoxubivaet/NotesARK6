﻿using NotesARK6.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesARK6.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCreateAndEditNote.xaml
    /// </summary>
    public partial class WindowCreateAndEditNote : Window
    {
        public WindowCreateAndEditNote(string title)
        {
            this.Resources.Add("Title", title);
            InitializeComponent();
            DataContext = new WindowCreateAndEditNoteViewModel();
        }
    }
}