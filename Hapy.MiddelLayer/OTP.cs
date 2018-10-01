using CommonLibrary;
using Hapy.DB;
using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class OTP : DbCommands<OTPVerification>, IOTP
    {
        private DbCommands<OTPVerification> _dbCommands;

        public OTP()
        {
            _dbCommands = new DbCommands<OTPVerification>();
        }

        public Models.OTP Insert(Models.OTP oTP)
        {
            OTPVerification oTPVerification = new OTPVerification()
            {
                oAccount = oTP.Account,
                oCode = (string)oTP.Code,
                oToken = Util.GenerateRandHashToken(),
                oVerifyed = false
            };
            _dbCommands.Insert(oTPVerification);
            bool status = _dbCommands.Save();
            return new Models.OTP()
            {
                Id = oTPVerification.oId,
                Code = oTPVerification.oCode,
                Account = oTPVerification.oAccount,
                Token = oTPVerification.oToken,
                isVerifyed = oTPVerification.oVerifyed
            };
        }

        public object Update(Models.OTP oTP)
        {
            var otpData = _dbCommands.FetchSingleRecord<OTPVerification>(oTP.Id);
            if (otpData != null)
            {
                if ((string)oTP.Code == otpData.oCode)
                {
                    otpData.oVerifyed = true;
                    bool status = _dbCommands.Save();
                    return new ActionReturn()
                    {
                        Status = status,
                        Id = otpData.oId,
                        Message = "OTP verifyed successfully."
                    };
                }
            }
            return new ActionReturn()
            {
                Status = false,
                Id = otpData.oId,
                Message = "Invalide OTP number."
            };
        }

        public IEnumerable<OTPSend> CheckSMSToSend(string name, object value)
        {
            IEnumerable<OTPVerification> accountList = _dbCommands.FetchRecords<OTPVerification>(name, value).ToList();
            List<OTPSend> _accountList = new List<OTPSend>();
            foreach (var item in accountList)
            {
                _accountList.Add(new Models.OTP()
                {
                    Account = item.oAccount,
                    isVerifyed = item.oVerifyed
                });
            }
            return _accountList;
        }
    }
}
