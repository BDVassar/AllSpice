namespace AllSpice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepository;

  public FavoritesService(FavoritesRepository favoritesRepository)
  {
    _favoritesRepository = favoritesRepository;
  }

  internal Favorite Create(Favorite favoriteData)
  {
    int id = _favoritesRepository.Create(favoriteData);
    favoriteData.id = id;
    return favoriteData;
  }

  internal List<FavoriteRecipe> GetMyFavorites(string id)
  {
    List<FavoriteRecipe> favorites = _favoritesRepository.GetMyFavorites(id);
    return favorites;
  }

  internal string Remove(int id, string accountId)
  {
    bool deleted = _favoritesRepository.Remove(id);
    if (deleted == false){
      throw new Exception("Favorite not deleted.");
    }
    return "Favorite was deleted";
  }
}
