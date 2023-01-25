import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async editAccount(accountInfo) {
    const res = await api.put('/account', accountInfo)
    // logger.log("[Account Edited", res.data)
    AppState.account = res.data
  }

  async GetMyFavorites() {
    const res = await api.get('account/favorites')
    // logger.log("[Got Favs]", res.data)
    AppState.recipes = res.data;
  }
}

export const accountService = new AccountService()
