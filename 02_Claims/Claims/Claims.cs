using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public enum ClaimTypes { Car = 1, Home, Theft}
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimTypes ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public Claims() { }
        public Claims(int claimId, ClaimTypes claimType, string claimDescription, decimal claimAmount, DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimId;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
