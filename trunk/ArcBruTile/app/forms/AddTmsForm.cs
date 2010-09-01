﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;

namespace BruTileArcGIS
{
    public partial class AddTmsForm : Form
    {
        private TileMap selectedTileMap=null;
        private List<TileMap> tilemaps;

        public AddTmsForm()
        {
            InitializeComponent();
        }

        public TileMap SelectedTileMap
        {
            get { return selectedTileMap; }
            set { selectedTileMap = value; }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            byte[] theBytes = client.DownloadData(tbTmsUrl.Text);
            string test = Encoding.UTF8.GetString(theBytes);
            client.Dispose();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(test);


            XmlNodeList nodes=doc.GetElementsByTagName("TileMap");
            
            tilemaps=new List<TileMap>();
            foreach (XmlNode node in nodes)
            {
                TileMap tileMap=new TileMap();
                tileMap.Href = node.Attributes["href"].Value;
                tileMap.Srs = node.Attributes["srs"].Value;
                tileMap.Profile = node.Attributes["profile"].Value;
                tileMap.Title= node.Attributes["title"].Value;
                tilemaps.Add(tileMap);
            }

            lbServices.DataSource = tilemaps;
            lbServices.DisplayMember = "Title";
        }

        private void AddTmsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbServices.SelectedItem != null)
            {
                selectedTileMap = (TileMap)lbServices.SelectedItem;
            }
        }
    }
}