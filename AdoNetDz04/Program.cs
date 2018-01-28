using System;
using System.Data;

namespace AdoNetDz04
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();

            DataTable trackEvaluationPart = new DataTable("TrackEvaluationPart");

            #region  trackEvaluationPart table

            //1 столбец первичный ключ
            DataColumn intEvalutionPartId = new DataColumn("intEvalutionPartId", typeof(int));
            intEvalutionPartId.AllowDBNull = false;
            intEvalutionPartId.Unique = true;
            intEvalutionPartId.ReadOnly = true;
            intEvalutionPartId.AutoIncrement = true;
            intEvalutionPartId.AutoIncrementSeed = 1;
            intEvalutionPartId.AutoIncrementStep = 1;

            //2 столбец внешний ключ
            DataColumn intEvalutionId = new DataColumn("intEvalutionId", typeof(int));
            intEvalutionId.AllowDBNull = true;

            //3 столбец внешний ключ
            DataColumn intMasterPartId = new DataColumn("intMasterPartId", typeof(int));
            intMasterPartId.AllowDBNull = false;

            //4 столбец 
            DataColumn floatQuantity = new DataColumn("floatQuantity", typeof(float));
            floatQuantity.AllowDBNull = true;

            //5 столбец
            DataColumn floatUnitCostTrack = new DataColumn("floatUnitCostTrack", typeof(float));
            floatUnitCostTrack.AllowDBNull = true;

            //6 столбец
            DataColumn floatUnitCostAvia = new DataColumn("floatUnitCostAvia", typeof(float));
            floatUnitCostAvia.AllowDBNull = true;

            //7 столбец
            DataColumn strAvailability = new DataColumn("strAvailability", typeof(string));
            strAvailability.AllowDBNull = true;
            strAvailability.MaxLength = 50;

            //8 столбец
            DataColumn strDescription = new DataColumn("strDescription", typeof(string));
            strDescription.AllowDBNull = true;
            strDescription.MaxLength = 2500;

            //9 столбец
            DataColumn intSimsld = new DataColumn("intSimsld", typeof(int));
            intSimsld.AllowDBNull = true;

            //10 столбец
            DataColumn intPartStatus = new DataColumn("intPartStatus", typeof(int));
            intPartStatus.AllowDBNull = true;

            trackEvaluationPart.PrimaryKey = new DataColumn[] { trackEvaluationPart.Columns["intEvalutionPartId"] };
            trackEvaluationPart.Columns.Add(intEvalutionPartId); //1 PK
            trackEvaluationPart.Columns.Add(intEvalutionId);     //2 FK
            trackEvaluationPart.Columns.Add(intMasterPartId);    //3 FK
            trackEvaluationPart.Columns.Add(floatQuantity);      //4
            trackEvaluationPart.Columns.Add(floatUnitCostTrack); //5
            trackEvaluationPart.Columns.Add(floatUnitCostAvia);  //6
            trackEvaluationPart.Columns.Add(strAvailability);    //7
            trackEvaluationPart.Columns.Add(strDescription);     //8
            trackEvaluationPart.Columns.Add(intSimsld);          //9
            trackEvaluationPart.Columns.Add(intPartStatus);      //10

            ds.Tables.Add(trackEvaluationPart);

            //Таблица для связи 
            DataTable intEvalution = new DataTable("intEvalution");
            DataColumn columnId = new DataColumn("ID", typeof(int));
            columnId.AllowDBNull = false;
            columnId.ReadOnly = true;
            columnId.AutoIncrement = true;
            columnId.AutoIncrementSeed = 1;
            columnId.AutoIncrementStep = 1;

            intEvalution.PrimaryKey = new DataColumn[] { intEvalution.Columns["ID"] };
            intEvalution.Columns.Add(columnId);

            ds.Tables.Add(intEvalution);

            //Таблица для связи
            DataTable intMasterPart = new DataTable("intMasterPart");
            DataColumn columnID = new DataColumn("ID", typeof(int));
            columnID.AllowDBNull = false;
            columnID.ReadOnly = true;
            columnID.AutoIncrement = true;
            columnID.AutoIncrementSeed = 1;
            columnID.AutoIncrementStep = 1;
            intMasterPart.PrimaryKey = new DataColumn[] { intMasterPart.Columns["ID"] };
            intMasterPart.Columns.Add(columnID);
            ds.Tables.Add(intMasterPart);


            DataRow intEvalutionRow = intEvalution.NewRow();
            intEvalutionRow.ItemArray = new object[] { null };
            intEvalution.Rows.Add(intEvalutionRow);

            DataRow intMasterPartRow = intMasterPart.NewRow();
            intMasterPartRow.ItemArray = new object[] { null };
            intMasterPart.Rows.Add(intMasterPartRow);

            DataRow trackEvaluationPartRow = trackEvaluationPart.NewRow();
            trackEvaluationPartRow.ItemArray = new object[] { null, intEvalutionRow["ID"], intMasterPartRow["ID"], 1, 2.26, 3.21, "string1", "string2", 32, 25 };
            trackEvaluationPart.Rows.Add(trackEvaluationPartRow);

            ds.Relations.Add("Evalutions", intEvalution.Columns["ID"], trackEvaluationPart.Columns["intEvalutionId"]);
            ds.Relations.Add("MasterParts", intMasterPart.Columns["ID"], trackEvaluationPart.Columns["intEvalutionId"]);



            Console.Write("intEPId intEId intMPId floQty fUCTrack fUCAvia strAvaty strDtn intSld intPStatus");
            Console.WriteLine("\n");
            MethodRow(trackEvaluationPart);
            #endregion


            #region second table

            DataTable tbl2 = new DataTable("TrackComponent");

            //1 столбец первичный ключ
            DataColumn intComponentId = new DataColumn("intComponentId", typeof(int));
            intComponentId.AllowDBNull = false;
            intComponentId.Unique = true;
            intComponentId.ReadOnly = true;
            intComponentId.AutoIncrement = true;
            intComponentId.AutoIncrementSeed = 1;
            intComponentId.AutoIncrementStep = 1;

            //2 столбец
            DataColumn strComponentId = new DataColumn("strComponentId", typeof(string));
            strComponentId.AllowDBNull = true;
            strComponentId.MaxLength = 12;

            //3 столбец
            DataColumn strUnti = new DataColumn("strUnti", typeof(string));
            strUnti.AllowDBNull = true;
            strUnti.MaxLength = 10;

            //4 столбец внешний ключ
            DataColumn intComponentTypeId = new DataColumn("intComponentTypeId", typeof(int));
            intComponentTypeId.AllowDBNull = true;

            //5 столбец
            DataColumn dInstalledOnMCS = new DataColumn("dInstalledOnMCS", typeof(DateTime));
            dInstalledOnMCS.AllowDBNull = true;

            //6 столбец
            DataColumn intEstimatedLife = new DataColumn("intEstimatedLife", typeof(int));
            intEstimatedLife.AllowDBNull = false;

            //7 столбец
            DataColumn dInitCycleDate = new DataColumn("dInitCycleDate", typeof(DateTime));
            dInitCycleDate.AllowDBNull = true;

            //8 столбец 
            DataColumn intInitCycleUnits = new DataColumn("intInitCycleUnits", typeof(int));
            intInitCycleUnits.AllowDBNull = true;

            //9 столбец
            DataColumn intInitTotalUnits = new DataColumn("intInitTotalUnits", typeof(int));
            intInitTotalUnits.AllowDBNull = true;

            //10 столбец внешний ключ
            DataColumn intEquipmentID = new DataColumn("intEquipmentID", typeof(int));
            intEquipmentID.AllowDBNull = true;

            //11 столбец
            DataColumn LastDate = new DataColumn("LastDate", typeof(DateTime));
            LastDate.AllowDBNull = false;

            //12 столбец
            DataColumn intLastMetered = new DataColumn("intLastMetered", typeof(float));
            intLastMetered.AllowDBNull = false;

            //13 столбец
            DataColumn intTotalMeterd = new DataColumn("intTotalMeterd", typeof(float));
            intTotalMeterd.AllowDBNull = true;

            //14 столбец внешний ключ
            DataColumn intSMCSComponentId = new DataColumn("intSMCSComponentId", typeof(int));
            intSMCSComponentId.AllowDBNull = true;

            //15 столбец внешний ключ
            DataColumn intModelID = new DataColumn("intModelID", typeof(int));
            intModelID.AllowDBNull = true;

            //16 столбец внешний ключ
            DataColumn intLocationId = new DataColumn("intLocationId", typeof(int));
            intLocationId.AllowDBNull = true;

            //17 столбец
            DataColumn isRemoved = new DataColumn("isRemoved", typeof(bool));
            isRemoved.AllowDBNull = true;

            //18 столбец
            DataColumn intStatusComponent = new DataColumn("intStatusComponent", typeof(int));
            intStatusComponent.AllowDBNull = true;

            //19 столбец внешний ключ
            DataColumn intModifierId = new DataColumn("intModifierId", typeof(int));
            intModifierId.AllowDBNull = true;

            tbl2.PrimaryKey = new DataColumn[] { tbl2.Columns["intComponentId"] };
            tbl2.Columns.Add(intComponentId);     //1
            tbl2.Columns.Add(strComponentId);     //2
            tbl2.Columns.Add(strUnti);            //3
            tbl2.Columns.Add(intComponentTypeId); //4 FK
            tbl2.Columns.Add(dInstalledOnMCS);    //5
            tbl2.Columns.Add(intEstimatedLife);   //6 
            tbl2.Columns.Add(dInitCycleDate);     //7
            tbl2.Columns.Add(intInitCycleUnits);  //8
            tbl2.Columns.Add(intInitTotalUnits);  //9
            tbl2.Columns.Add(intEquipmentID);     //10 FK
            tbl2.Columns.Add(LastDate);           //11
            tbl2.Columns.Add(intLastMetered);     //12
            tbl2.Columns.Add(intTotalMeterd);     //13
            tbl2.Columns.Add(intSMCSComponentId); //14 FK
            tbl2.Columns.Add(intModelID);         //15 FK
            tbl2.Columns.Add(intLocationId);      //16 FK
            tbl2.Columns.Add(isRemoved);          //17
            tbl2.Columns.Add(intStatusComponent); //18
            tbl2.Columns.Add(intModifierId);      //19 FK

            ds.Tables.Add(tbl2);
            #endregion

            #region third table

            DataTable tbl3 = new DataTable("PMCheckListPart");
            ds.Tables.Add(tbl3);

            //1 столбец первичный ключ
            DataColumn intPMCheckListPartID = new DataColumn("intPMCheckListPartID", typeof(int));
            intPMCheckListPartID.AllowDBNull = false;
            intPMCheckListPartID.Unique = true;
            intPMCheckListPartID.ReadOnly = true;
            intPMCheckListPartID.AutoIncrement = true;
            intPMCheckListPartID.AutoIncrementSeed = 1;
            intPMCheckListPartID.AutoIncrementStep = 1;

            tbl3.PrimaryKey = new DataColumn[] { tbl3.Columns["intPMCheckListPartID"] };
            tbl3.Columns.Add(intPMCheckListPartID);

            //2 столбец внешний ключ
            DataColumn intPMCheckListStepID = new DataColumn("intPMCheckListStepID", typeof(int));
            intPMCheckListStepID.AllowDBNull = false;

            tbl3.Columns.Add(intPMCheckListStepID);

            //3 столбец
            DataColumn strPartNo = new DataColumn("strPartNo", typeof(string));
            strPartNo.AllowDBNull = true;
            strPartNo.MaxLength = 20;

            tbl3.Columns.Add(strPartNo);

            //4 столбец
            DataColumn intQuantity = new DataColumn("intQuantity", typeof(int));
            intQuantity.AllowDBNull = false;

            tbl3.Columns.Add(intQuantity);

            //5 столбец
            DataColumn intExtendedCost = new DataColumn("intExtendedCost", typeof(int));
            intExtendedCost.AllowDBNull = true;

            tbl3.Columns.Add(intExtendedCost);

            //6 столбец
            DataColumn bitOptional = new DataColumn("bitOptional", typeof(bool));
            bitOptional.AllowDBNull = true;

            tbl3.Columns.Add(bitOptional);

            //7 столбец
            DataColumn intOriginalPartId = new DataColumn("intOriginalPartId", typeof(int));
            intOriginalPartId.AllowDBNull = true;

            tbl3.Columns.Add(intOriginalPartId);

            //8 столбец
            DataColumn strPartDescription = new DataColumn("strPartDescription", typeof(string));
            strPartDescription.AllowDBNull = true;
            strPartDescription.MaxLength = 550;

            tbl3.Columns.Add(strPartDescription);

            //9 столбец внешний ключ 
            DataColumn intMasterPartID = new DataColumn("intMasterPartId", typeof(int));
            intMasterPartID.AllowDBNull = false;

            tbl3.Columns.Add(intMasterPartID);

            //10 столбец
            DataColumn intPMCheckListID = new DataColumn("intPMCheckListID", typeof(int));
            intPMCheckListID.AllowDBNull = true;

            tbl3.Columns.Add(intPMCheckListID);

            #endregion



        }

        private static void MethodRow(DataTable dt)
        {
            foreach (DataRow r in dt.Rows)
            {
                foreach (var cell in r.ItemArray)
                    Console.Write("{0}\t", cell);
                Console.WriteLine();
            }
        }
    }


}
