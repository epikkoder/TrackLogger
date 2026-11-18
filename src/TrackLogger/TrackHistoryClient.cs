using System.Net.Http.Json;

namespace TrackLogger;

public sealed class TrackHistoryClient(HttpClient http)
{
    public async Task<IReadOnlyList<Track>> GetRecentTracksAsync(int channelId, CancellationToken ct)
    {
        var items = await http.GetFromJsonAsync<List<TrackHistoryItem>>(
            $"track_history/channel/{channelId}", Json.Options, ct) ?? [];

        return [.. items.Select(item => item.ToTrack()).OfType<Track>()];
    }
}