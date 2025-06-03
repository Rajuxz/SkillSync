import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import { RouterProvider } from 'react-router';
import { createBrowserRouter } from 'react-router';
import { ToastContainer } from 'react-toastify';
import { Hero } from './components/index.js';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Hero />,
    index: true,
  },
  {
    path: '/dashboard',
    element: <h1>Hello Dashboard.</h1>,
  },
]);

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <ToastContainer autoClose={3000} />
    <RouterProvider router={router} />
  </StrictMode>
);
