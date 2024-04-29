'use client'
import React, {useEffect} from "react"
import axios from "axios"
import { toast } from "react-toastify"
import { useSession } from "next-auth/react"

export default function SignUpForm()
{
const [formData, setFormData] = React.useState({
    fullname:"",
    username: "",
    email: "",
    password: "",
})
const session = useSession();

const onSubmit = async (e) => {
    e.preventDefault();
    if(!formData.username) return;
    try {
        let newFormdata = {
            ...formData}
        const response = await axios.post("http://localhost:5103/api/User/register", newFormdata);
        
        console.log(response)
        
        toast.success("Account created successfully")
        
    } catch (error) {
        toast.error("Something went wrong")
    }
}
const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;

    const currentInputFieldData = {
        [name]: value,
    }

    const updatedData = {
        ...formData,
        ...currentInputFieldData,
    }
    setFormData(updatedData)
}

    return(
        <div className="w-96 border"> 
        <div className="bg-pink-900 text-white text-center h-28 grid place-items-center rounded-t-lg"> 
        <h3 className="text-2xl">Create Account</h3>
        </div> 
        <div className="p-4">
             <div className="mb-4"> 
             <label for="name" className="block text-gray-700 font-bold mb-2">Full Name</label> 
             <input 
             onChange={handleChange}
             type="text" 
             id="fullname" 
             name="fullname" 
             placeholder="enter full name" 
             className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
             required /> 
             </div> 
             <div className="mb-4"> 
             <label for="name" className="block text-gray-700 font-bold mb-2">user name</label> 
             <input 
             onChange={handleChange}
             type="text" 
             id="username" 
             name="username" 
             className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
             required /> 
             </div> 
             <div className="mb-4">
                 <label for="email" className="block text-gray-700 font-bold mb-2">email address</label>
                  <input 
                    onChange={handleChange} 
                    type="email" 
                    id="email" 
                    name="email" 
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" required /> 
                  </div>
                   <div className="mb-4">
                     <label for="password" className="block text-gray-700 font-bold mb-2">enter password</label> 
                     <input 
                        onChange={handleChange} 
                        type="password" 
                        id="password" 
                        name="password" 
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" required /> 
                     </div> 
                     
                            </div>
                             <div className="bg-pink-900 text-white text-center p-4 rounded-b-lg">
                                 <button onClick={onSubmit} className="bg-white text-teal-900 font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" >
                                    Create Account
                                    </button> 
                                    <p className="text-sm mt-4">have an account? proceed to <a href="/login" className="text-blue-gray font-bold">Sign in</a></p> 
                                    <p className="text-center text-white-500 text-xs">
                                        &copy;2024 Max Mulla. All rights reserved.
                                    </p>
                                    </div>
</div>
    )
}