namespace AllSpice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int Create(Favorite favoriteData)
  {
    string sql = @"
    INSERT INTO favorites
    (accountId, recipeId)
    Values
    (@accountId, @recipeId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, favoriteData);
    return id;
  }

  internal List<FavoriteRecipe> GetMyFavorites(string id)
  {
    string sql = @"
    SELECT
    ac.*,
    fav.*,
    rec.*
    FROM favorites fav
    JOIN recipes rec ON rec.id = fav.id
    JOIN accounts ac ON rec.creatorId = ac.id
    WHERE fav.accountId = @id;
    ";
    List<FavoriteRecipe> favorites = _db.Query<Account, Favorite, FavoriteRecipe, FavoriteRecipe>(sql, (ac, fav, rec) =>
    {
      rec.favoriteId = fav.id;
      rec.creator = ac;
      return rec;
    }, new { id }).ToList();
    return favorites;
  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE FROM favorites
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;
  }
}
