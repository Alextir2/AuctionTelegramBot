using System.ComponentModel;

namespace AuctionBot.Db.Enums;

public enum Role : byte
{
    [Description("Нет роли")]
    None,
    
    [Description("Продавец")]
    Seller,
    
    [Description("Покупатель")]
    Buyer
}