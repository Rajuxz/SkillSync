import { toast } from 'react-toastify';

export const toastServices = {
  warn: (message) => toast.warn(message),
  success: (message) => toast.success(message),
  error: (message) => toast.error(message),
  info: (message) => toast.info(message),
};
