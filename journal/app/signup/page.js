import { UserCircleIcon } from "@heroicons/react/24/solid";
import SignUpForm from "../components/forms/signupForm";
export default function Page()
{
    return(
        <div className="relative h-screen overflow-hidden bg-white dark:bg--100">
            <div className="flex justify-center items-center mt-6">
            <div className="w-full max-w-md space-y-8 px-4 py-6 bg-white rounded-md shadow-sm">
            <UserCircleIcon className="mx-auto h-12 w-auto text-pink-800" />
            <h2 className="mt-4 text-center text-3xl font-bold tracking-tight text-pink-900">
                SoulScript
            </h2>
            <SignUpForm />
                </div>
           
            </div>
            
        </div>
    )
}