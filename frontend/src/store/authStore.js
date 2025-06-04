import axios from 'axios';
import { create } from 'zustand';
const useAuthStore = create((set) => ({
  //initial state
  isAuthorized: null,
  isLoading: false,
  checkAuth: async () => {
    set({ isLoading: true });
    try {
      const response = await axios.get(
        'https://localhost:7111/api/Auth/check',
        { withCredentials: true }
      );
      if (response.status === 200) {
        set({ isAuthorized: true, isLoading: false });
      } else {
        set({ isAuthorized: false, isLoading: false });
      }
    } catch (error) {
      console.log('Error:' + error);
      set({ isAuthorized: false, isLoading: false });
    }
  },
}));

export default useAuthStore;
