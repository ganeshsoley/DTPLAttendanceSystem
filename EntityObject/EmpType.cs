using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class EmpType: BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;

        private Int32 dbID;
        private string empTypeFName;
        private string empTypeSName;
        private string otFormula;
        private string minOT;
        private string lcGraceTime;
        private string egGraceTime;
        private int calculateHalfDay;
        private string halfDayMins;
        private int calculateAbsentDay;
        private string absentDayMins;
        private int markWOHasBothDayAbsent;

        #endregion

        public EmpType()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;
        }
    }
}
