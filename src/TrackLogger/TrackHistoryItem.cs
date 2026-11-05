namespace TrackLogger;

internal sealed record TrackHistoryItem(long? TrackId, string? Artist, string? Title, string? Type)
{
    public Track? ToTrack()
    {
        if (Type is not "track")
        return null;

        if (TrackId is not { } id || string.IsNullOrWhiteSpace(Artist) || string.IsNullOrWhiteSpace(Title))
        return null;

        return new Track(id, Artist.Trim(), Title.Trim());
    }
}