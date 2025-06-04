import React, { useEffect } from 'react';
import useAuthStore from '../../store/authStore';
import { Navigate } from 'react-router';
const PublicRoute = ({ children }) => {
  const { isAuthorized, isLoading, checkAuth } = useAuthStore();

  useEffect(() => {
    if (isAuthorized === null) {
      checkAuth();
    }
  }, [isAuthorized, checkAuth]);

  if (isLoading || isAuthorized === null) {
    return <p className="animate-bounce">Checking Connection ....</p>;
  }

  if (isAuthorized) {
    //If user is authorized, redirect away from signin page.
    return <Navigate to="/dashboard" replace />;
  }

  return children;
};

export default PublicRoute;
