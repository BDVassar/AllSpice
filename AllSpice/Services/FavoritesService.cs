using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _favoritesrepository;

  public FavoritesService(FavoritesRepository favoritesrepository)
  {
    _favoritesrepository = favoritesrepository;
  }

  internal Favorite Create(Favorite favoriteData)
  {
    int id = _favoritesrepository.Create(favoriteData);
    favoriteData.id = id;
    return favoriteData;
  }
}
