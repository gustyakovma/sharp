using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASTRALib;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace MPTCompare.lib
{
    class Rezim
    {
        const int ModeNormal = 0;
        const int ModeFlat = 1;
        string[] ModeObj = new string[2]{"Обычный", "Плоский"};
        

        public Rastr rastr1 {get; set;}
        public Rastr rastr2 { get; set; }
        public int startPoint{get; set;}
        

        public Rezim()
        {
            startPoint = 0;
        }
        
        public void CheckConvergenceMode(DataGridView DGV)
        {
            List<Array> ItemsList = new List<Array>();
            ItemsList.Add(getModeObj(rastr1)); // 1- мегаточка
            ItemsList.Add(getModeObj(rastr2)); // 2 - мегаточка

            ArrToGrid(DGV, ItemsList);
        }

        // получить двумерный массив для растра
        private Array getModeObj(Rastr rst)
        {
            string modeMessage = string.Empty; ;
            RastrCalc(rst);

            string[,] paramsArr = new string[2, 24 - startPoint + 1];


            for (int i = startPoint - 1; i < 24; i++)
            {
                paramsArr[ModeNormal,i] = "0";
                paramsArr[ModeFlat, i] = "0";

                if (rst.rgm("") == RastrRetCode.AST_NB)
                {
                    modeMessage += String.Format("Режим не сбалансирован в точке {0} проверить с плоского старта \n", i);

                    if (rst.rgm("p") == RastrRetCode.AST_NB)
                        modeMessage += String.Format("Режим не сбалансирован в точке {0} проверить с плоского старта \n", i);
                    else
                    {
                        modeMessage += String.Format("режим в точке {0} сошёлся с плоского старта \n", i);
                        paramsArr[ModeFlat, i] = "5";
                    }
                    rst.Printp(String.Format("Режим в точке {0} не сбалансирован", i));
                }
                else
                    paramsArr[ModeNormal, i] = "5";

                if (modeMessage == string.Empty)   //если режим сбалансирован
                    rst.WritePnt(i);
                else
                    MessageBox.Show(modeMessage);
            }

            return paramsArr;
        }

        // вычисление по формуле (0) ?
        public void RastrCalc(Rastr rst)
        {
            ASTRALib.table tableRst = (ASTRALib.table)rst.Tables.Item("MultiPntConfig");
            ASTRALib.col colRst = (ASTRALib.col)tableRst.Cols.Item("Significance");
            colRst.Calc("0"); 
        }

        private void ArrToGrid(DataGridView DGV, List<Array> ItemsList)
        {
            DGV.Columns.Add("MpName", "Название мегаточки");
            DGV.Columns.Add("MpStart", "Старт");

            for (int i = 1; i <= 24; i++)
            {
                DataGridViewColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.Width = 30;
                newColumn.Name = i.ToString();
                newColumn.HeaderText = i.ToString(); 
                DGV.Columns.Add(newColumn);
            }
            
            for (int listItemNum = 0; listItemNum < ItemsList.Count; listItemNum++)
            {
                int p = DGV.Rows.Count - 1;
                string[,] mptArr = (string[,])ItemsList[listItemNum];
               
                string[] RowValuesObj = new string[2] {"Название", ModeObj[0] };
                DGV.Rows.Add(RowValuesObj);

                for (int i = 0; i < mptArr.GetLength(0); i++) //разбор двумерного массива с параметрами
                {
                    if (i == 1)
                    {
                        DGV.Rows.Add(new object[] { "", ModeObj[1] });
                    }

                    for (int j = 0; j < mptArr.GetLength(1); j++)
                    {
                        // расскрашивание ячеек
                        DataGridViewCell CurCell = DGV.Rows[p + i].Cells[2 + j];
                        int mptVal = Int32.Parse(mptArr[i, j]);
                        if (i == ModeNormal)
                        {
                            if (mptVal == 5) CurCell.Style.BackColor = Color.GreenYellow;
                            if (mptVal != 5) CurCell.Style.BackColor = Color.Blue;
                            if (mptVal != 5 && Int32.Parse(mptArr[i + 1, j]) == 5) CurCell.Style.BackColor = Color.GreenYellow;
                            if (mptVal != 5 && Int32.Parse(mptArr[i + 1, j]) != 5) CurCell.Style.BackColor = Color.Blue;
                        }
                    }
                }
                DGV.Rows.Add("");
            }       
        }

    }
}
