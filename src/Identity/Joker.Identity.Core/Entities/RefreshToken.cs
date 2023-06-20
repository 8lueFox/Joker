namespace Joker.Identity.Core.Entities;

public class RefreshToken : AggregateRoot
{
    public AggregateId UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    public bool Revoked => RevokedAt.HasValue;

    public RefreshToken(AggregateId id, AggregateId userId, string token, DateTime createdAt,
        DateTime? revokedAd = null)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new EmptyRefreshTokenException();

        Id = id;
        UserId = userId;
        Token = token;
        CreatedAt = createdAt;
        RevokedAt = revokedAd;
    }

    public void Revoke(DateTime revokedAt)
    {
        if (Revoked)
            throw new RevokedRefreshTokenException();

        RevokedAt = revokedAt;
    }
}
