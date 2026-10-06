namespace BlazorIdentityApiDemo.Data
{
    public class EnableTwoFactorRequest
    {
        public bool Enable { get; set; }

        public bool ResetSharedKey { get; set; }

        public string? TwoFactorCode { get; set; }

        public bool ResetRecoveryCodes { get; set; }
    }
    public class TwoFactorResponse
    {
        public string? SharedKey { get; set; }

        public string[]? RecoveryCodes { get; set; }

        public int RecoveryCodesLeft { get; set; }

        public bool IsTwoFactorEnabled { get; set; }
    }
}
