import axios from 'axios';

const config = {
  withCredentials: true,
};
export const authServices = {
  signup: async (data) => {
    // eslint-disable-next-line no-useless-catch
    try {
      const res = await axios.post(
        'https://localhost:7111/api/Auth/register',
        data,
        config
      );
      return res;
    } catch (error) {
      throw error;
    }
  },
};
