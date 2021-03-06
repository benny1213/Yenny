﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//todo: 添加数据库支持
//todo：添加左侧栏scrollviewer

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 英语学习系统.Scenes
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShowVideo : Page
    {
        public ShowVideo()
        {
            this.Loaded += ShowVideo_Loaded;
            this.InitializeComponent();
        }
        Video[] videos = new Video[3];

        private async void ShowVideo_Loaded(object sender, RoutedEventArgs e)
        {
            DBControl dBControl = new DBControl();
            videos = dBControl.readvideo();
            StorageFolder folder = await(Windows.Storage.KnownFolders.VideosLibrary).GetFolderAsync("uwpVideo");
            try
            {
                var file = await folder.GetFileAsync("1.mp4");
                if (file != null)
                {
                    Windows.Storage.Streams.IRandomAccessStream
                    stream = await file.OpenAsync(FileAccessMode.Read);
                    this.meVoideo.SetSource(stream, "");
                    this.meVoideo.Play();
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }
    }
}
