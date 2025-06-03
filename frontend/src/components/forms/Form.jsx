import { useState } from 'react';
import { authServices } from '../../services/authService';
import { toastServices } from '../../services/toastService';
import { useNavigate } from 'react-router';
const Form = () => {
  //navigate
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
  });
  const handleChange = (event) => {
    //get the event target which gives the input field being focused with changing value
    const { name, value } = event.target;
    // set form data using setFormData()
    setFormData((prev) => ({
      ...prev,
      [name]: value, // get the name and set the value
    }));
  };
  const handleSubmit = async function () {
    try {
      const res = await authServices.signup(formData);
      if (res.status === 200) {
        toastServices.success('Account created successfully.');
        navigate('/dashboard');
      }
    } catch (ex) {
      toastServices.error('Something went wrong.' + ex);
    }
  };
  return (
    <>
      <form method="post" className="max-w-sm">
        <div className="w-full mb-5 flex items-center justify-between gap-5">
          <div className="w-full">
            <label
              htmlFor="firstName"
              className="block mb-2 text-sm font-medium text-gray-900 "
            >
              First Name
            </label>
            <input
              type="text"
              name="firstName"
              id="firstName"
              onChange={handleChange}
              className="bg-gray-50 border border-gray-300 text-sm rounded-lg block w-full p-2.5"
              placeholder="John"
              required
            />
          </div>
          <div className="w-full">
            <label
              htmlFor="lastName"
              className="block mb-2 text-sm font-medium "
            >
              Last Name
            </label>
            <input
              type="text"
              name="lastName"
              onChange={handleChange}
              id="lastName"
              className="bg-gray-50 border  text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 "
              placeholder="Doe"
              required
            />
          </div>
        </div>
        <div className="mb-5">
          <label htmlFor="email" className="block mb-2 text-sm font-medium">
            Your email
          </label>
          <input
            type="email"
            id="email"
            name="email"
            onChange={handleChange}
            className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
            placeholder="johndoe@skillsync.com"
            required
          />
        </div>
        <div className="mb-5">
          <label
            htmlFor="password"
            className="block mb-2 text-sm font-medium text-gray-900"
          >
            Your password
          </label>
          <input
            name="password"
            onChange={handleChange}
            type="password"
            id="password"
            placeholder="*****"
            className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
            required
          />
        </div>
        <div className="flex items-start mb-5">
          <div className="flex items-center h-5">
            <input
              id="remember"
              type="checkbox"
              value=""
              className="w-4 h-4 border border-gray-300 rounded-sm bg-gray-50 focus:ring-3 focus:ring-blue-300 "
            />
          </div>

          <label
            htmlFor="remember"
            className="ms-2 text-sm font-medium text-gray-900"
          >
            Remember me
          </label>
        </div>
        <button
          type="button"
          onClick={handleSubmit}
          className="text-white bg-primary focus:ring-4 focus:outline-none focus:ring-primary font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center "
        >
          Sign Up
        </button>

        <div className="mt-3">
          <div className="mb-4 ">
            <span>Already have an account? </span>
            <a href="#" className="text-primary">
              Login Here
            </a>
          </div>
        </div>
      </form>
    </>
  );
};

export default Form;
