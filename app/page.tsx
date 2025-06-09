import { getSession } from "./libs";
export default async function page() {
  const session = getSession()
  console.log(JSON.stringify(session))
  return (
    <div>
      <form>
        <button>Hi</button>
        <button></button>
        {session && (
          <div>{JSON.stringify(session,null,2)}</div>
        )}
      </form>
    </div>
  );
}
