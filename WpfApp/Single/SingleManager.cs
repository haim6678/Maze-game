﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using WpfApp.Single.PreGame;

namespace WpfApp.Single
{
    class SingleManager
    {
        private PreSingleGameWindow pre { get; set; }
        private SinglePlayerView SingleView { get; set; }
        private PreViewModel preVM { get; set; }
        private PreSingleModel preModel { get; set; }
        private SinglePlayerModel model { get; set; }
        private SinglePlayerViewModel SingleVM { get; set; }

        public SingleManager()
        {
            preModel = new PreSingleModel();
            preModel.NotifStart += Manage;
            preVM = new PreViewModel(preModel);
            pre = new PreSingleGameWindow(preVM);
            pre.ShowDialog();
        }

        public void Manage()
        {
            pre.Close();

            model = new SinglePlayerModel();
            model.HandleFinish += Finish;
            SingleVM = new SinglePlayerViewModel(model);
            SingleView = new SinglePlayerView(SingleVM);
            SingleView.Show();
        }

        private void Finish()
        {
            SingleView.Close();
        }
    }
}