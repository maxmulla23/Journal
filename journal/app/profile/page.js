'use client'
import React, { useState, Fragment } from "react"
import { Textarea } from "@/components/ui/textarea"
import { Input } from "@/components/ui/input"
import axios from "axios"
import { useSession } from "next-auth/react"
import { toast } from "react-toastify"
import { UserCircleIcon } from "@heroicons/react/24/solid"
import { Dialog, Transition } from "@headlessui/react"
import Journals from "../components/Journals"
// const User = {
//     fullname: 'Iweene Wanjiru',
//     username: 'Iweene',
//     email: 'Iweene@gmail.com',

// }
export default function Page() {
    const [data, setData] = useState()
    const session = useSession();
    let [isOpen, setIsOpen] = useState(false)
    const [formData, setFormData] = useState({
      title: "",
      content: "",
      userId: session?.data?.user?.userId,
      user: session?.data?.user?.user
      
  })
  const handleSubmit = async (e) => {
      e.preventDefault();
      try {
          let newFormdata = {
              ...formData,
          }
          const response = await axios.post("http://localhost:5103/api/Journal", newFormdata)
          console.log(response)
          toast.success("Journal added successfully!")
      } catch (error) {
          console.log(error);
          toast.error("an error occurred!")
      }
  }
  const handleChange = (e) => {
      const name = e.target.name;
      const value = e.target.value

      const currentInputFieldData = {
          [name] : value
      }
      const updatedData = {
          ...formData,
          ...currentInputFieldData,
      }
      setFormData(updatedData)
  }
    function closeModal() {
        setIsOpen(false)
    }
    function openModal() {
        setIsOpen(true)
    }

    return(
        <div className="flex flex-row mt-10 md:flex-row">
            <h1 className="text-pink-900 font-bold text-2xl md:text-lg ml-9">Welcome back {session?.data?.user?.fullName}</h1>
            <div className="flex flex-col md:flex-col text-pink-900 mt-7">
                <div className="ml-10 pl-7">
                <UserCircleIcon className="h-44 w-auto md:h-22" />
                <h1 className=" ml-10 mt-3  text-3xl md:text-lg text-pink-900">{session?.data?.user?.username}</h1>
                </div>
            </div>
            <div className="flex flex-col md:flex-col ml-8 mt-12">
            <h1 className="text-4xl md:text-2xl text-pink-950">{session?.data?.user?.email}</h1>
            <h2 className="text-pink-800 mt-2 text-lg">{session?.data?.user?.fullName}</h2>
            
            <button 
            type="button"
            onClick={openModal}
            className="bg-pink-700 mt-3 hover:bg-pink-900 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" >
                New Journal
            </button>
            <Transition appear show={isOpen} as={Fragment}>
        <Dialog as="div" className="relative z-10" onClose={closeModal}>
          <Transition.Child
            as={Fragment}
            enter="ease-out duration-300"
            enterFrom="opacity-0"
            enterTo="opacity-100"
            leave="ease-in duration-200"
            leaveFrom="opacity-100"
            leaveTo="opacity-0"
          >
            <div className="fixed inset-0 bg-black/25" />
          </Transition.Child>

          <div className="fixed inset-0 overflow-y-auto">
            <div className="flex min-h-full items-center justify-center p-4 text-center">
              <Transition.Child
                as={Fragment}
                enter="ease-out duration-300"
                enterFrom="opacity-0 scale-95"
                enterTo="opacity-100 scale-100"
                leave="ease-in duration-200"
                leaveFrom="opacity-100 scale-100"
                leaveTo="opacity-0 scale-95"
              >
                <Dialog.Panel className="w-full max-w-md transform overflow-hidden rounded-2xl bg-white p-6 text-left align-middle shadow-xl transition-all">
                  <Dialog.Title
                    as="h3"
                    className="text-lg font-medium leading-6 text-pink-900"
                  >
                    Soul Script
                  </Dialog.Title>
                  <div className="mt-2">
                  <div>
            <h1>Journal Form</h1>
            <Input 
            onChange={handleChange}
            name="title"
            type="text"
            className="mt-4" placeholder="type title here" />
            <Textarea 
            onChange={handleChange}
            name="content"
            type="text"
            className="mt-4" placeholder="type content here" />
            <button 
             type="button"
             className="mt-4 inline-flex justify-center rounded-md border border-transparent bg-pink-100 px-4 py-2 text-sm font-medium text-pink-900 hover:bg-red-200 focus:outline-none focus-visible:ring-2 focus-visible:ring-red-500 focus-visible:ring-offset-2"
             onClick={handleSubmit}
            >Create</button>
        </div>
                  </div>

                  <div className="mt-4">
                    <button
                      type="button"
                      className="inline-flex justify-center rounded-md border border-transparent bg-blue-100 px-4 py-2 text-sm font-medium text-blue-900 hover:bg-blue-200 focus:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:ring-offset-2"
                      onClick={closeModal}
                    >
                      Close
                    </button>
                  </div>
                </Dialog.Panel>
              </Transition.Child>
            </div>
          </div>
        </Dialog>
      </Transition>
            <hr className="mt-8 border-solid border-black" />
            <div className="mt-10 p-4">
            <Journals />
            </div>
            

            </div>
            
        </div>
        
    )
}