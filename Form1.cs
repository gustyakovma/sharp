using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ASTRALib;
using MPTCompare.lib;
using System.Linq;



namespace MPTCompare
{
    public partial class Form1 : Form
    {
        Rastr rst1;
        Rastr rst2;
        private TMpt Mpt1 = new TMpt();
        private TMpt Mpt2 = new TMpt();
        private bool rst1load = false;
        private bool rst2load = false;
        private int startCalcPoint;

        public Dictionary<string, DataTable> DTables = new Dictionary<string, DataTable>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                rst1 = new Rastr();
                rst2 = new Rastr();
            }
            catch (Exception Err)
            {
                MessageBox.Show("Ошибка создания объекта actopus.\r\n Возможно, программа actopus не установлена.\r\n Ошибка:" + Err.Message.ToString());
                Close();
            }
            LoadXmlConfig();
        }


        // загрузить config
        private bool LoadXmlConfig()
        {
            cbTables.Items.Clear();
            XmlDocument ConfigXMLdoc = new XmlDocument();
            try
            {
                ConfigXMLdoc.Load(Application.StartupPath + "\\MPTCompareConfig.xml");
            }
            catch (Exception Err)
            {
                MessageBox.Show("Ошибка загрузки конфигурационного файла MPTCompareConfig.xml\r\n" + Err.Message);
                return false;
            }
            XmlNodeList testnodelist = ConfigXMLdoc.GetElementsByTagName("config");
            if (testnodelist.Count == 0)
            {
                MessageBox.Show("Конфигурационный файл не содержит описания " + "config");
                return false;
            }
            XmlNode treenode = testnodelist[0];
            foreach (XmlNode node in treenode.ChildNodes)
            {
                if(node.Attributes["Enable"].Value.ToString() != "True")
                    continue;
                
                DataTable dt = new DataTable(node.Attributes["Name"].Value);

                DataColumn cln = new DataColumn(node.Attributes["KeyName"].Value.ToString());
                cln.Caption = "ID";
                dt.Columns.Add(cln);

                DataColumn cln2 = new DataColumn(node.Attributes["KeyNameDesc"].Value.ToString());
                cln2.Caption = "Наименование";
                dt.Columns.Add(cln2);


                DataColumn cln3 = new DataColumn("Point");
                cln3.Caption = "Точка";
                dt.Columns.Add(cln3);
                
                cbTables.Items.Add(node.Attributes["Desc"].Value.ToString());
                foreach (XmlNode nodeparam in node.ChildNodes)
                {
                    if (nodeparam.Attributes["Enable"].Value != "True")
                        continue;
                    DataColumn clmn = new DataColumn(nodeparam.Attributes["Name"].Value);
                    clmn.Caption = nodeparam.Attributes["Desc"].Value;
                    dt.Columns.Add(clmn);
                }

                if (dt.Columns.Count > 2) // если хоть одна характеристика импортируется?
                {
                    DTables.Add(node.Attributes["Desc"].Value, dt);
                }               
            }
            if (cbTables.Items.Count > 0)
                cbTables.SelectedIndex = 0;

            return true;
        }

        private void CompareMPT()
        {

            int scp1 = Mpt1.GetStartColPOint(rst1);
            string key = cbTables.SelectedItem.ToString();
            
            DataTable dt1 = Mpt1.MTables[key];
            dg.Columns.Clear();
            dg.Rows.Clear();
            string[] colm = new string[dt1.Columns.Count];
            DataColumnCollection dcc = dt1.Columns;
            for (int c = 0; c < 2; c++)
            {
                  dg.Columns.Add(dcc[c].ColumnName, dcc[c].Caption);
            }
            dg.Columns.Add("columnch", "Характеристика");

            for(int p=scp1;p<=24;p++)
                dg.Columns.Add(p.ToString(), p.ToString());
            
            //DataRow[] fRows1 = dt1.Select("Num = 1", dt1.Columns[1].ColumnName+","+dt1.Columns[2].ColumnName);
            DataRow[] fRows1 = dt1.Select(null, dt1.Columns[1].ColumnName);

            Object PrevID = -1;
            int i = 0;
            int dgObjects = 0;
            while (i < fRows1.Length)
            {
                Object CurID = fRows1[i].ItemArray[0];
                if (CurID.ToString() != PrevID.ToString())
                {
                    for (int cc = 3; cc < dcc.Count; cc++)
                    {
                        Object[] v1 = new object[dg.Columns.Count];
                        if (cc == 3)
                        {
                            v1[0] = fRows1[i].ItemArray[0];
                            v1[1] = fRows1[i].ItemArray[1];
                        }
                        v1[2] = dcc[cc].Caption;
                        DataGridViewRow drow = new DataGridViewRow();
                        drow.CreateCells(dg, v1);
                        dg.Rows.Add(drow);

                        int cp = 0;
                        Object[] dasd = new object[30];
                        for (int ip = i; ip <= i + (24 - scp1);ip++ )
                        {
                            dg.Rows[dgObjects*3+cc-3].Cells[3 + cp].Value = fRows1[ip].ItemArray[cc];
                            cp++;
                            dasd[cp] = fRows1[ip].ItemArray[cc]; ;
                        }

                    }
                    PrevID = CurID;
                    i = i + (24 - scp1) * (dcc.Count-3);
                    dgObjects++;
                    continue;
                }
                i++;
            }

            Cursor.Current = Cursors.Default;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            cbTables.Enabled=true;
        }

        // загрузка 1ой мегаточки
        private void btnMPTLoad1_Click(object sender, EventArgs e)
        {
            string MtpLoadPath = Mpt1.GetMptLoadingPath();
            if (MtpLoadPath != String.Empty)
            {
                if (Mpt1.LoadMPT(rst1, MtpLoadPath, DTables)) rst1load = true;
                lblMpt1.Text = MtpLoadPath; 
                CheckEnableCompare();
            }
        }

        // загрузка 2ой мегаточки
        private void btnMPTLoad2_Click(object sender, EventArgs e)
        {
            string MtpLoadPath = Mpt1.GetMptLoadingPath();
            if (MtpLoadPath != String.Empty)
            {
                if (Mpt2.LoadMPT(rst2, MtpLoadPath, DTables)) rst2load = true;
                lblMpt2.Text = MtpLoadPath;
                CheckEnableCompare();
            }
        }

        // состояние кнопки сравнить в зависимости от загрузки мегаточек
        private void CheckEnableCompare()
        {
            btnCompare.Enabled = rst1load && rst2load;
        }


        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rst1load && cbTables.Enabled)
              CompareMPT();
        }

        //@TODO ПОТОМ УДАЛИТЬ
        private void button1_Click(object sender, EventArgs e)
        {
            if (Mpt1.LoadMPT(rst1, "c:\\bofer\\120311-17_перенумерованный.mpt", DTables)) rst1load = true;
            lblMpt1.Text = "c:\\bofer\\120311-17_перенумерованный.mpt";

            if (Mpt2.LoadMPT(rst2, "c:\\bofer\\130311-01.mpt", DTables)) rst2load = true;
            lblMpt2.Text = "c:\\bofer\\130311-01.mpt";
            
            CheckEnableCompare(); // проверка возможности сравнить мегаточки


            startCalcPoint = Math.Max(Mpt1.GetStartColPOint(rst1), Mpt2.GetStartColPOint(rst2)); 
            TMpt.SetMptList(rst1, Mpt1, rst2, Mpt2); // создается список из MPT obj  в нужной последовательности
            
            //CompareTablesData(dgvAgregate, "РГЕ");
        }

        // сравнить мегаточки
        private void btnCompare_Click(object sender, EventArgs e)
        {
            //CompareMPT();
            startCalcPoint = Math.Max(Mpt1.GetStartColPOint(rst1), Mpt2.GetStartColPOint(rst2));
            CompareTablesData(dgvAgregate, "РГЕ");
        }


        public void CompareTablesData(DataGridView DGV, string keyName)
        {

            DataTable dt1 = TMpt.MPTList[0].MTables[keyName];
            DataTable dt2 = TMpt.MPTList[1].MTables[keyName];

            // получить все неповторяющиеся id агрегатов
            var AgrIds = (  from row in dt1.Select("","Num asc").AsEnumerable()
                            select row["Num"]).Distinct();
  
            foreach (string AgrId in AgrIds) // перебор всех id агрегатов
            {   
                DataRow[] fRows1 = dt1.Select( string.Format("Num='{0}' and Point >= {1}", AgrId, startCalcPoint), "Point ASC");
                DataRow[] fRows2 = dt2.Select(string.Format("Num='{0}' and Point >= {1}", AgrId, startCalcPoint), "Point ASC");

                DGV.ColumnCount = 28;
                DGV.ColumnHeadersVisible = true;

                Dictionary<string, int> ColParams = new Dictionary<string, int>(); //словарь с колонками
                for (int i = 4; i < 6; i++)
                {
                    if (!isComparedObjects(fRows1, fRows2, i)) 
                    {
                        ColParams.Add(dt1.Columns[i].ColumnName.ToString(), i);
                    }
                }
                if (ColParams.Count > 0)
                    ExportToDataGrid(fRows1, fRows2, ColParams, DGV);       
            }
        }

        public void ExportToDataGrid(DataRow[] frow1, DataRow[] frow2, Dictionary<string, int> ColParams, DataGridView DGV)
        {

            int p = DGV.Rows.Count - 1;
            bool firstCol = true;
            foreach (KeyValuePair<string, int> ColParam in ColParams) //Pmax, Pmin
            {
                object[] RowValuesObj = new object[3];
                if (firstCol)
                {
                    RowValuesObj[0] = frow1[0].ItemArray[1].ToString();
                    RowValuesObj[1] = frow1[0].ItemArray[0].ToString();
                    firstCol = false;
                }
                RowValuesObj[2] = ColParam.Key;
                DGV.Rows.Add(RowValuesObj);


                for (int i = startCalcPoint - 1; i < 24; i++)
                {
                    if (i == startCalcPoint - 1)
                    {
                        DGV.Rows.Add(new object[] { "", "", ColParam.Key });
                        DGV.Rows.Add(new object[] { "", "", "Delta" });
                    }     

                    var param1 = frow1[i].ItemArray[ColParam.Value].ToString();
                    var param2 = frow2[i].ItemArray[ColParam.Value].ToString();
                    if ((Double.Parse(param2) - Double.Parse(param1)) != 0)
                    {
                        DGV.Rows[p].Cells[3 + i].Value = param1;
                        DGV.Rows[p + 1].Cells[3 + i].Value = param2;
                        DGV.Rows[p + 2].Cells[3 + i].Value = Double.Parse(param2) - Double.Parse(param1);
                    }   
                }
                p = p + 3;     
            }
            DGV.Rows.Add("");
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        // сравнение мегаточек на интервале от старта и до 24
        public bool isComparedObjects(DataRow[] fRows1, DataRow[] fRows2, Int32 ColumnID)
        {
            for (int i = startCalcPoint - 1; i < 24; i++)
                {
                    if (fRows1[i].ItemArray[ColumnID].ToString() != fRows2[i].ItemArray[ColumnID].ToString()) return false;
                }
            return true;
        }

        // постройка дерева из таблиц с их типами
        private void button2_Click(object sender, EventArgs e)
        {
            trvTables.BeginUpdate();
            ASTRALib.Tables t = (ASTRALib.Tables)rst1.Tables;
            for (int i = 0; i < t.Count; i++)
            {
                ASTRALib.table tblAstra = (ASTRALib.table)t.Item(i);
                TreeNode newNode = new TreeNode();
                newNode.Text = String.Format("{0} ({1})", tblAstra.Name, tblAstra.Cols.Count);
                for (int j = 0; j < tblAstra.Cols.Count; j++)
                {
                    ASTRALib.col col = (ASTRALib.col)tblAstra.Cols.Item(j);
                    TreeNode ColumnNode = new TreeNode();
                    int ColumnTypeId = Int32.Parse(col.get_Prop(ASTRALib.PropType.FL_TIP).ToString());
                    ColumnNode.Text = String.Format("{0}({1})", col.Name, Helper.GetTypeNameById(ColumnTypeId));
                    newNode.Nodes.Add(ColumnNode);
                }
                trvTables.Nodes.Add(newNode);
            }
            trvTables.CollapseAll();
            trvTables.EndUpdate();
        }

        private void btnGetRezim_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
                Rezim rez = new Rezim();
                rez.rastr1 = rst1;
                rez.rastr2 = rst2;
                rez.startPoint = startCalcPoint;
                rez.CheckConvergenceMode(dgvRezim);
            Cursor.Current = Cursors.Default;
        }

    
    }

}