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

namespace MPTCompare.lib
{
    class TMpt
    {

        public static List<TMpt> MPTList = new List<TMpt>();
        public Dictionary<string, DataTable> MTables = new Dictionary<string, DataTable>();

        // получить список мегаточек в нужной последовательности
        public static void SetMptList(Rastr rst1, TMpt Mpt1, Rastr rst2, TMpt Mpt2)
        {
            
            ASTRALib.table t1 = (ASTRALib.table)rst1.Tables.Item("MltPntSettings");
            ASTRALib.col c1 = (ASTRALib.col)t1.Cols.Item("AbsTime");
            Double mpt1StartDate = (Double)c1.get_Z(0);

            ASTRALib.table t2 = (ASTRALib.table)rst2.Tables.Item("MltPntSettings");
            ASTRALib.col c2 = (ASTRALib.col)t2.Cols.Item("AbsTime");
            Double mpt2StartDate = (Double)c2.get_Z(0);
            if (mpt1StartDate < mpt2StartDate)
            {
                MPTList.Add(Mpt1);
                MPTList.Add(Mpt2);
            }
            else
            {
                MPTList.Add(Mpt2);
                MPTList.Add(Mpt1);
            } 
        }

        
       
        // получить номер точки начала расчета
        public int GetStartColPOint(Rastr rst)
        {
            ASTRALib.table t = (ASTRALib.table)rst.Tables.Item("MltPntSettings");
            ASTRALib.col c = (ASTRALib.col)t.Cols.Item("StartCalcPoint");
            return (int)c.get_Z(0);
        }

        public bool LoadMPT(Rastr rst, string mptpath, Dictionary<string, DataTable> DTables)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                rst.Load(ASTRALib.RG_KOD.RG_REPL, mptpath, "");
            }
            catch (Exception Err)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Не удалось загрузить файл мегаточки " + mptpath + "\r\n" + Err.Message);
                return false;
            }

            rst.OutZero = 1;
            
            RastrRetCode retcode = rst.CheckMegapoint();
            if (retcode != RastrRetCode.AST_OK)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Мегаточка не загружена");
                return false;
            }
            FillMpt(rst, DTables); // DTABLES формируется при распарсивании xml
            return true;
        }

        public void FillMpt(Rastr rst, Dictionary<string, DataTable> DTables)
        {
            MTables.Clear();
            foreach (KeyValuePair<string, DataTable> kvp in DTables)
            {
                DataTable newdt = kvp.Value.Copy();
                MTables.Add(kvp.Key, newdt);
            }
            
            int scp1 = GetStartColPOint(rst);
            for (int i = scp1; i <= 24; i++)
            {
                rst.ReadPnt(i, 0);

                foreach (KeyValuePair<string, DataTable> kvp in MTables)
                {
                    ASTRALib.table GenTab = (ASTRALib.table)rst.Tables.Item(kvp.Value.TableName);

                    int colcount = kvp.Value.Columns.Count;

                    //Object[] Myrow = new object[colcount];
                    int x = GenTab.get_FindNextSel(-1);
                    while (x >= 0)
                    {
                        Object[] mycells = new Object[colcount];
                        string KeyName = kvp.Value.Columns[0].ColumnName;
                        object key = (int)((ASTRALib.col)GenTab.Cols.Item(kvp.Value.Columns[0].ColumnName)).get_Z(x);
                        object KeyNameDecs = (object)((ASTRALib.col)GenTab.Cols.Item(kvp.Value.Columns[1].ColumnName)).get_Z(x);

                        var colT = (ASTRALib.col)GenTab.Cols.Item(3);
                        var colType = colT.get_Prop(ASTRALib.PropType.FL_TIP).ToString();

                        mycells[0] = key;
                        mycells[1] = KeyNameDecs;
                        mycells[2] = i;
                        

                        for (int c = 3; c < colcount; c++)  // читаем остальные параметры
                        {
                            mycells[c] =
                                (Object)((ASTRALib.col)GenTab.Cols.Item(kvp.Value.Columns[c].ColumnName)).get_Z(x);
                        }
                        kvp.Value.Rows.Add(mycells);
                        x = GenTab.get_FindNextSel(x);
                    }
                }
            }
        }

        //загрузить мегаточку и получить путь к ней
        public string GetMptLoadingPath()
        {
            string path = String.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файлы мегаточки (*.mpt)|*.mpt|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName;
            }
            return path;
        }


       /* public static string getColumnDescr(Rastr rst, string ColumnName)
        {
            ASTRALib.Tables t = (ASTRALib.Tables)rst.Tables;

        }
        /*
                public static string getColumnType(Rastr rst, string TableName)
                {
                    ASTRALib.table t1 = (ASTRALib.table)rst.Tables.Item(TableName);
                   ASTRALib.col c1 = (ASTRALib.col)t1.Cols.Item("AbsTime");
                   return c1.get_Prop(ASTRALib.PropType.FL_TIP).ToString();
                }
         */
    }
}
